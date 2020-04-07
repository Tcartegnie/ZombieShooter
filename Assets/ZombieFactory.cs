using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieFactory : MonoBehaviour
{
	public GameObject Zombie;
	public SoundDatabase sounddatabase;
	public static ZombieFactory instance;

	public static ZombieFactory Instance()
	{
		if (instance == null)
		{
			GameObject InstanceObject = new GameObject("GameManager");
			InstanceObject.AddComponent<ZombieFactory>();
		}
		return instance;
	}

	public void Awake()
	{
		instance = this;
	}

	public GameObject InstanciateZombie(Vector3 WorldPosition)
	{
		GameObject GO = Instantiate(Zombie, WorldPosition ,new Quaternion());
		SoundPlayer sound = GO.GetComponentInChildren<SoundPlayer>();
		sound.SoundList = sounddatabase.GetSoundListsByName(sound.ListName);
		GO.GetComponentInChildren<Zombie>().StalkPlayer = true;
		return GO;
	}

	public GameObject InstanciateEntityByName(string name,Vector3 WorldPosition)
	{
		switch(name)
		{
			case ("Zombie"):
				return InstanciateZombie(WorldPosition);
			
		}
		return new GameObject();
	}

}
