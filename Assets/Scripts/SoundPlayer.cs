using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	int IDSoundPlayer = 0;
	public SoundsListData SoundDatas;
	public AudioSource SoundSource;
	public Transform Player;

	public void Awake()
	{
		SoundDatas.InitSoundsData();
	}

	public float GetnormalizedTargetDistance(float MaxDistance)
	{
		float distance = Vector3.Distance(transform.position, Player.position);
		float test = (MaxDistance / distance);
		return Mathf.Clamp(test, 0, 1);
	}

	public void PlayRandomSound(string RandomListName)
	{
		SoundSource.PlayOneShot(SoundDatas.GetRandomSound(RandomListName),GetnormalizedTargetDistance(10));
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
