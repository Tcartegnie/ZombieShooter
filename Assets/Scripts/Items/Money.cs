using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
	public int Value;
	public Transform Fxtransform;
	public AudioClip DropSound;
	public AudioClip LootSound;
	public AudioSource SoundPlayer;

	public void Update()
	{
		Fxtransform.rotation = Quaternion.LookRotation(Vector3.up);
	}
	public AudioClip GetDropSound()
	{
		return LootSound;
	}

	public void OnCollisionEnter(Collision collision)
	{
		SoundPlayer.PlayOneShot(DropSound);
	}

}
