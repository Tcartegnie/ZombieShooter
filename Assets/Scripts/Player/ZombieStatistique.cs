using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStatistique : CharacterStatistique
{
	public Animator ZombieClip;
	public NavMeshAgent agent;
	public Zombie Zombie;
	public ZombieCollision Collider;
	public Collider ColliderBullet;
	public ZombieWaveManager ZombieWavesManager; 

	public override void Death()
	{
		base.Death();
		ZombieClip.enabled = false;
		Zombie.PauseNavMeshAgent();
		Collider.Push();
		ColliderBullet.enabled = (false);
		ZombieWavesManager.OnZombieDeath();
	}

}
