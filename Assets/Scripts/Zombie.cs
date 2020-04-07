using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	public SoundPlayer Sounds;
	public NavMeshAgent agent;
	public Transform target;
	public float AttackLenght;

	[SerializeField]
	Animator animator;

	public bool StalkPlayer;

	public GameObject FootstepFX;

	public void Start()
	{
		animator.SetInteger("IDAttack", Random.Range(0, 2));
	}

	public void Update()
	{
		if (StalkPlayer)
		{
			SetTarget();
			CheckAttackDistance();
		}
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
		if( GetTargetDistance() < AttackLenght)
		{
			transform.LookAt(target);
			CallAttack();
		}
	}

	public void CallAttack()
	{
		agent.velocity = Vector3.zero;
		animator.SetTrigger("Attack");
	}

	public void AttackTarget()
	{
		if (StalkPlayer)
		{
			if (GetTargetDistance() < AttackLenght)
			{
				Vector3 test = transform.position - target.position;
				float dotproduct = Vector3.Dot(test, target.right);
				target.GetComponent<CharacterStatistique>().Hit(2);
			}
			animator.SetInteger("IDAttack", Random.Range(0, 2));
			Sounds.PlayRandomSound("AttackCAC");
		}
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

	public void RemoveTarget()
	{
		StalkPlayer = false;
	}

	public void PauseNavMeshAgent()
	{
		agent.isStopped = true;
	}

	public void EneableNavMeshAgent()
	{
		agent.isStopped = false;
	}

}
