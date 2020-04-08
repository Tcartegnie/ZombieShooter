using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
	public SoundPlayer Sounds;
	public GameObject Bloodparticles;
	public CharacterStatistique stats;
	public Rigidbody hips;
	Transform LastColliderHit;
	public float ReplusStrengh;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == ("Bullet"))
		{
			Hit(other.gameObject);
		}
	}

	public virtual void Hit(GameObject collision)
	{
		stats.Hit(collision.GetComponent<Bullet>().GetDamage());
		PlayFx(collision.transform);
		LastColliderHit = collision.transform;
	}

	public void PlayFx(Transform ImpactPoint)
	{
		Instantiate(Bloodparticles, ImpactPoint.position, Quaternion.LookRotation(ImpactPoint.forward));
	}

	public Transform GetLastColliderHit()
	{
		return LastColliderHit;
	}
	public void Push()
	{
		hips.AddForce(LastColliderHit.forward * ReplusStrengh);
	}
}
