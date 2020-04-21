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
	ZombieFactory factory;


	List<GameObject> InstanciedZombies = new List<GameObject>();

	int WaveIndex = 0;

	public void Start()
	{
		factory = ZombieFactory.instance;
		StartCoroutine(InstanciatedZombiesWave(ZombieWave[0]));
	}

	public IEnumerator InstanciatedZombiesWave(ZombieWaveData data)
	{
		scoreManager.SetMaxZombieCount(data.type.Count);
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
		scoreManager.UpdateScore();
		InstanciedZombies.Remove(zombie);
		CheckZombieWaveState();
	}


	public void InstantaiteNewWave()
	{
		StartCoroutine(InstanciatedZombiesWave(ZombieWave[WaveIndex]));
		scoreManager.ResetCountKiller();
	}

	public void CheckZombieWaveState()
	{
		if(InstanciedZombies.Count == 0)
		{
			WaveIndex += 1;
			if (WaveIndex < ZombieWave.Count)
			{
				InstantaiteNewWave();
			}
			else if(WaveIndex == ZombieWave.Count)
			{
				ExitLevel.SetActive(true);
			}
		}
	}
}
