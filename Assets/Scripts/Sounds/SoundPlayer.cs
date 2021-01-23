using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	int IDSoundPlayer = 0;
	public string ListName;
	public AudioSource SoundSource;

	public SoundsListData SoundList;


	public void PlayRandomSound(string RandomSoundName)
	{
		SoundSource.PlayOneShot(SoundList.GetRandomSound(RandomSoundName));
	}

	public void PlayFootStepSound()
	{
		PlayRandomSound("Foostep");
	}

	public void PlayHitSound()
	{
		PlayRandomSound("Hit");
	}
}
