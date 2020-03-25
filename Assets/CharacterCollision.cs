using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
	public SoundPlayer Sounds;
	public GameObject Bloodparticles;
	public CharacterStatistique stats;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == ("Bullet"))
		{
			stats.Hit(collision.gameObject.GetComponent<Bullet>().GetDamage(),0);
			Destroy(collision.gameObject);
			BloodEmission(collision.transform);
			Sounds.PlayRandomSound("ZombieHit");
		}
	}


	public void BloodEmission(Transform ImpactPoint)
	{
		Instantiate(Bloodparticles, ImpactPoint.position, Quaternion.LookRotation(ImpactPoint.forward));
	}
}
