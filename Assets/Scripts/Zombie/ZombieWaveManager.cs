using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaveManager : MonoBehaviour
{
	public EndGameScript endGame;
	public ScoreManager scoreManager;
	public Transform[] ZombiesSpawn;
	public List<ZombieWaveData> ZombieWave;
	public float ZombieSpawnTime;
	public Transform target;
	public GameObject ExitLevel;
	public ScoreUI scoreUI;
	ZombieFactory factory;
	public int CurrentZombieCOunt;

	List<GameObject> InstanciedZombies = new List<GameObject>();
	public GameObject NextWaveScreen;


	int WaveIndex = 0;

	public void Start()
	{
		factory = ZombieFactory.Instance();
		scoreManager = ScoreManager.Instance();
		StartCoroutine(InstanciatedZombiesWave(ZombieWave[0]));
	}

	public IEnumerator InstanciatedZombiesWave(ZombieWaveData data)
	{
		scoreManager.SetMaxZombieCount(data.type.Count);
		scoreUI.ZombieMaxWave = data.type.Count;
		for (int i= 0; i < data.type.Count; i++ )
		{
			GameObject zombie = factory.InstanciateEntityByName(data.type[i], ZombiesSpawn[Random.Range(0,ZombiesSpawn.Length)].position);
			zombie.GetComponentInChildren<Zombie>().target = target;
			zombie.GetComponent<ZombieStatistique>().ZombieWavesManager = this;
			InstanciedZombies.Add(zombie);
			 yield return new WaitForSeconds(ZombieSpawnTime);
		}
		
	}

	public void OnZombieDeath(GameObject zombie)
	{
		scoreManager.AddScore(10);
		scoreManager.AddCountKiller();
		InstanciedZombies.Remove(zombie);
		scoreUI.CurrentZombiecount += 1;
		scoreUI.DisplayZombieCount();
		scoreUI.DisplayScoreCount();
		CheckZombieWaveState();
	}


	public void InstantaiteNewWave()
	{
		StartCoroutine(InstanciatedZombiesWave(ZombieWave[WaveIndex]));
		scoreUI.ResetCountKiller();
	}

	public void CheckZombieWaveState()
	{
		if(InstanciedZombies.Count == 0)
		{
			WaveIndex += 1;
			if (WaveIndex < ZombieWave.Count)
			{
				StartCoroutine(NextWaveSign());
			}
			else if(WaveIndex == ZombieWave.Count)
			{
				ExitLevel.SetActive(true);
			}
		}
	}

	public IEnumerator NextWaveSign()
	{ 
		for (int i = 0; i < 3; i++)
		{
			NextWaveScreen.SetActive(true);
			yield return new WaitForSeconds(0.5f);
			NextWaveScreen.SetActive(false);
			yield return new WaitForSeconds(0.5f);
		}
		InstantaiteNewWave();
	}
}
