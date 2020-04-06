using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
	public SoundPlayer Sounds;
	public GameObject Bloodparticles;
	public CharacterStatistique stats;

	private void OnCollisionEnter(UnityEngine.Collision collision)
	{
		if (collision.gameObject.tag == ("Bullet"))
		{
			Hit(collision);
		}
	}

	public void Hit(UnityEngine.Collision collision)
	{
		stats.Hit(collision.gameObject.GetComponent<Bullet>().GetDamage());
		Destroy(collision.gameObject);
		PlayFx(collision.transform);
		Sounds.PlayRandomSound("ZombieHit");
	}

	public void PlayFx(Transform ImpactPoint)
	{
		Instantiate(Bloodparticles, ImpactPoint.position, Quaternion.LookRotation(ImpactPoint.forward));
	}

}
