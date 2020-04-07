using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatistique : MonoBehaviour
{
	public float PV;
	public float MaxPV;
	[SerializeField]
	protected Animator animator;
	public bool IsAlive = true;

	public void Start()
	{
		IsAlive = true;
	}


	public void Update()
	{
		if(Input.GetKey(KeyCode.K))
		{
			Hit(1);
		}
	}



	public virtual void ManageLifeBar(){}


	public virtual void Hit(int damage)
	{
		PV -= damage;
		ManageLifeBar();
		if(CheckPV())
		{
			CallDeath();
		}
	}

	public void PlayHitAnimation(float hitdirection)
	{
		animator.SetFloat("HitDirection", hitdirection);
		animator.SetTrigger("OnHit");
	}


	

	public float GetComputeScore()//Propre au joueur
	{
		float Result = (PV / MaxPV);
		Debug.Log(Result);
		return Result;
	}


	public bool CheckPV()
	{
		if (PV <= 0)
		{
			return true;
		}
		return false;
	}

	

	public virtual void CallDeath()
	{

	}

}
