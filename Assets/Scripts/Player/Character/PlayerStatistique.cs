using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistique : CharacterStatistique
{
	public LifeBar lifebar;

	public delegate void OnDeath();

	public OnDeath ondeath;

	public override void ManageLifeBar()
	{
		lifebar.SetBarValue(GetComputeScore());
	}

	public override void Hit(int damage)
	{
		base.Hit(damage);
		PlayHitAnimation(0);
	}

	public override void Death()
	{
		if (IsAlive)
		{
			ondeath();
			gameObject.SetActive(false);
			IsAlive = false;
		}

	}
}
