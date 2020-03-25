using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatistique : MonoBehaviour
{
	public int PV;
	[SerializeField]
	Animator animator;

	public void Hit(int damage, float hitdirection)
	{
		PV -= damage;
		CheckPV();
		animator.SetFloat("HitDirection", hitdirection);
		animator.SetTrigger("OnHit");
	}

	public void CheckPV()
	{
		if (PV <= 0)
		{
			Destroy(gameObject);
		}
	}



}
