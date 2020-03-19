using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	public SoundPlayer Sounds;   
	public NavMeshAgent agent;
	public Transform target;
	public float PV;
	public float TargetOffset;
	[SerializeField]
	Animator animator;

	public SkinnedMeshRenderer mesh;

	public GameObject Bloodparticles;	


	public void Update()
	{
		SetTarget();
		CheckAttackDistance();
		//mesh = GetComponentInParent<SkinnedMeshRenderer>();
		//Debug.Log(GetnormalimeszedTargetDistance(5));
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
		Sounds.PlayRandomSound("AttackCAC");
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
		if (collision.gameObject.tag == ("Bullet"))
		{
			Hit(collision.gameObject.GetComponent<Bullet>().GetDamage());
			Destroy(collision.gameObject);
			BloodEmission(collision.transform);
			Sounds.PlayRandomSound("ZombieHit");
		}
	}

	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.gameObject.tag == ("Bullet"))
	//	{
	//		Hit(other.gameObject.GetComponent<Bullet>().GetDamage());
	//		Destroy(other.gameObject);
	//		BloodEmission(other.transform);
	//		Sounds.PlayRandomSound("ZombieHit");
	//	}
	//}


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

	public void BloodEmission(Transform ImpactPoint)
	{
	
	//	Vector3 [] Verticesposition = mesh.sharedMesh.vertices;
	//	Vector3 ClosestImpactPosition  = GetClostesPoint(ImpactPoint.position,Verticesposition);
		Instantiate(Bloodparticles, ImpactPoint.position,Quaternion.LookRotation(ImpactPoint.forward));
		//Debug.Break();
	}



}
