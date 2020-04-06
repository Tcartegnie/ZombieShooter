using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieFactory : MonoBehaviour
{
	public GameObject Zombie;
	public SoundDatabase sounddatabase;

	public void InstanciateZombie(Vector3 WorldPosition)
	{
		GameObject GO = Instantiate(Zombie, WorldPosition ,new Quaternion());
		SoundPlayer sound = GO.GetComponentInChildren<SoundPlayer>();
		sound.SoundList = sounddatabase.GetSoundListsByName(sound.ListName);
		GO.GetComponentInChildren<Zombie>().StalkPlayer = true;
	}

}
