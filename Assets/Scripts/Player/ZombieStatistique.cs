using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStatistique : CharacterStatistique
{
	public override void Death()
	{
		Destroy(gameObject);
	}
}
