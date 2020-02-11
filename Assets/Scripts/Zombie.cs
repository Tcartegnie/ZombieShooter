using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
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
	}

	public void SetTarget()
	{
		Vector3 VectorTargetOffset = transform.position - target.position;
		VectorTargetOffset.Normalize();
		VectorTargetOffset *= TargetOffset;
		agent.SetDestination(target.position + VectorTargetOffset);

		animator.SetFloat("Speed", agent.velocity.magnitude);
	}


	public void CheckAttackDistance()
	{
		if(Vector3.Distance(transform.position, target.position) < 2)
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
			target.GetComponent<CharacterMovement>().Hit(2);
		}
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


	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == ("Bullet"))
		{
			Hit(collision.gameObject.GetComponent<Bullet>().GetDamage());
			Destroy(collision.gameObject);
		}
	
	}
}
