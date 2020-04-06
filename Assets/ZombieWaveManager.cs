using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaveManager : MonoBehaviour
{
	public Transform[] ZombiesSpawn;
	public List<int> ZombieWave;
	public PlayerStatistique playerStatistique;


	public void Start()
	{
		InstanciatedZombiesWave(ZombieWave[0]);

	}

	public void InstanciatedZombiesWave(int ZombieNumber)
	{
		for(int i= 0; i < ZombieNumber;i++ )
		{
			InstantiateZombie();
		}
	}

	public void InstantiateZombie()
	{

	
	}
}
