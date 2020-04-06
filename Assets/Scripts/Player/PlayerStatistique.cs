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

	public override void Death()
	{
		ondeath();
		gameObject.SetActive(false);
	}
}
