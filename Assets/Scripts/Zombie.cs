using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	public SoundPlayer Sounds;   
	public AudioSource ZombieAttackSound;

	public NavMeshAgent agent;
	public Transform target;
	public float PV;
	public float TargetOffset;
	[SerializeField]
	Animator animator;




	


	public void Update()
	{
		SetTarget();
		CheckAttackDistance();

		//Debug.Log(GetnormalizedTargetDistance(5));
	}

	public void SetTarget()
	{
		agent.SetDestination(target.position);

		animator.SetFloat("Speed", agent.velocity.magnitude);
	}


	public float GetTargetDistance()
	{
		return Vector3.Distance(transform.position, target.position);
	}



	public void CheckAttackDistance()
	{
		if( GetTargetDistance() < 2)
		{
			CallAttack();
		}
	}

	public void CallAttack()
	{
		animator.SetTrigger("Attack");
	}

	public void AttackTarget()
	{
		if (Vector3.Distance(transform.position, target.position) < 2)
		{
			Vector3 test = transform.position - target.position;
			float dotproduct = Vector3.Dot(test,target.right);
			target.GetComponent<CharacterMovement>().Hit(2,dotproduct);
		}
		//ZombieAttackSound.Play();
	}
	

	public void Hit(float Damage)
	{
		PV -= Damage;
		CheckDamage();
	}

	public void CheckDamage()
	{
		if(PV <= 0)
		{
			Debug.Log("Death");
			Destroy(gameObject);
		}
		else
		{
			Debug.Log("Ha ha ha ha STILL ALLLIIIIIIIIIIIIIIIIIIVE");
		}
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == ("Bullet"))
		{
			Hit(other.gameObject.GetComponent<Bullet>().GetDamage());
			Destroy(other.gameObject);
			//	SoundSource.PlayOneShot(HitSound,GetnormalizedTargetDistance(10));
			//SoundSource.Play(HitScream,GetnormalizedTargetDistance(10));
			Sounds.PlayRandomSound("ZombieHit");
		}
	}


	public void PlayHitScreamSound()
	{
		Sounds.PlayRandomSound("ZombieHit");
	}

	public void PlayZedsExpressiveNoise()
	{
		Sounds.PlayRandomSound("ZombieHit");
	}

}
