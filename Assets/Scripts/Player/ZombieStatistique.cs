using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStatistique : CharacterStatistique
{
	public Animator ZombieClip;
	public NavMeshAgent agent;
	public override void CallDeath()
	{
		base.CallDeath();
		ZombieClip.enabled = false;
	}


	public void Death()
	{
		//Destroy(gameObject);
	
	}
}
