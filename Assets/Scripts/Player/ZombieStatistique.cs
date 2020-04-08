using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStatistique : CharacterStatistique
{
	public Animator ZombieClip;
	public NavMeshAgent agent;
	public Zombie zombie;
	public ZombieCollision collider;
	public Collider ColliderBullet;
	public override void CallDeath()
	{
		base.CallDeath();
		ZombieClip.enabled = false;
		zombie.PauseNavMeshAgent();
		collider.Push();
		ColliderBullet.enabled = (false);
	}
}
