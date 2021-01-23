using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : CharacterCollision
{
	public Animator clip;



	public override void Hit(GameObject other)
	{
		base.Hit(other);
		clip.SetTrigger("Hit");

	}

}
