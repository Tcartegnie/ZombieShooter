using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : CharacterCollision
{
	public Animator clip;



	public override void Hit(GameObject collision)
	{
		base.Hit(collision);
		//Sounds.PlayRandomSound("ZombieHit");
		clip.SetTrigger("Hit");
	
		//PlayHitAnimation;
	}

}
