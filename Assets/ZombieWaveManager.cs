using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaveManager : MonoBehaviour
{
	public Transform[] ZombiesSpawn;
	public List<int> ZombieWave;
	public float ZombieSpawnTime;
	public Transform target;
	ZombieFactory factory;


	public void Start()
	{
		factory = ZombieFactory.instance;
	 StartCoroutine(InstanciatedZombiesWave(ZombieWave[0]));
	
	}

	public IEnumerator InstanciatedZombiesWave(int ZombieNumber)
	{
		for(int i= 0; i < ZombieNumber;i++ )
		{
			GameObject zombie = factory.InstanciateEntityByName("Zombie", ZombiesSpawn[Random.Range(0,ZombiesSpawn.Length)].position);
			zombie.GetComponentInChildren<Zombie>().target = target;
			yield return new WaitForSeconds(ZombieSpawnTime);
		}
	}

}
