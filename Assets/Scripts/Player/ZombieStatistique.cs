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
	public MoneyDropper money;
	public float DestroyBodyTimer;

	public override void Death()
	{
		base.Death();
		ZombieClip.enabled = false;
		Zombie.PauseNavMeshAgent();
		Collider.Push();
		ColliderBullet.enabled = (false);
		ZombieWavesManager.OnZombieDeath();
		money.DropMoney();
		StartCoroutine(DestroyCorps());
	}

	public IEnumerator DestroyCorps()
	{
		yield return new WaitForSeconds(DestroyBodyTimer);
		Destroy(gameObject);
	}

}
