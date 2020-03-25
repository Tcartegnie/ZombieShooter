using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	public SoundPlayer Sounds;
	public NavMeshAgent agent;
	public Transform target;

	[SerializeField]
	Animator animator;

	public GameObject FootstepFX;

	public void Update()
	{
		SetTarget();
		CheckAttackDistance();
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
			target.GetComponent<CharacterStatistique >().Hit(2,dotproduct);
		}
		Sounds.PlayRandomSound("AttackCAC");
	}
	

	public Vector3 GetClostesPoint(Vector3 Position,Vector3[] points)
	{
		Vector3 ClosestPosition = Position;
		float ClosestDistance = Mathf.Infinity;
		for (int i = 0; i < points.Length; i++)
		{
			float distance = Vector3.Distance(Position, points[i]);
			if(distance < ClosestDistance)
			{
				ClosestPosition = points[i];
			}
		}
		return ClosestPosition;
	}



	public void PlayFootstepFX()
	{
		Instantiate(FootstepFX, transform.position, new Quaternion());
	}

}
