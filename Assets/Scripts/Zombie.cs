using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	public AudioSource SoundSource;
	public AudioClip HitSound;
	public AudioSource HitScream;

	public AudioSource ZombieAttackSound;

	public NavMeshAgent agent;
	public Transform target;
	public float PV;
	public float TargetOffset;
	[SerializeField]
	Animator animator;

	public List<AudioClip> FootstepSound = new List<AudioClip>();
	public List<AudioClip> HitSounds = new List<AudioClip>();
	public List<AudioClip> ZedsExpresiveNoise = new List<AudioClip>();


	int IDSoundPlayer = 0;


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

	public float GetnormalizedTargetDistance(float MaxDistance)
	{
		float distance = Vector3.Distance(transform.position,target.position);
		float test = (MaxDistance/ distance);
		return Mathf.Clamp(test,0,1);
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
		ZombieAttackSound.Play();
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
			SoundSource.PlayOneShot(HitSound,GetnormalizedTargetDistance(10));
			//SoundSource.Play(HitScream,GetnormalizedTargetDistance(10));
			if (HitScream.isPlaying == false)
			{
				HitScream.volume = GetnormalizedTargetDistance(10);
				HitScream.Play();
			}
		}
	}


	public void PlayRandomSound(List<AudioClip>Sounds)
	{
		int SoundPlayed = 0;
		do
		{
			SoundPlayed = Random.Range(0, Sounds.Count);
		}
		while (IDSoundPlayer == SoundPlayed);

		IDSoundPlayer = SoundPlayed;
		float SoundVolume = GetnormalizedTargetDistance(10);
		Debug.Log(SoundVolume);
		SoundSource.PlayOneShot(Sounds[SoundPlayed], SoundVolume);
	}

	public void PlayFootStepSound()
	{
		PlayRandomSound(FootstepSound);
	}

	public void PlayHitScreamSound()
	{
		PlayRandomSound(FootstepSound);
	}

	public void PlayZedsExpressiveNoise()
	{
		PlayRandomSound(ZedsExpresiveNoise);
	}

	/*
	 1- Faire un gun, et un mitraillette
	 2- Caler l'animation sur le Gun et la mitraillette
	 3- Faire des pieges
	 4- Faire le scoring
	 5- Faire un shop
	 */
}
