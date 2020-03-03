using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public float Speed;
	[SerializeField]
	Transform camera;
	public bool InMove;
	[SerializeField]
	Animator animator;

	[SerializeField]
	CharacterShoot charactershoot;
	public int PV;
	public float RotationSpeed;
	Rigidbody rb;
	public CharacterController characterController;
	Vector3 direction;
	public DashMovement Dashmovement;
	

	public void StopMovement()
	{
		rb = GetComponent<Rigidbody>();
		InMove = false;
	}



	public void Walk(float ForwardInput, float LateralInput)
	{
		direction = GetForwardDirection(ForwardInput) + GetLateralDirection(LateralInput);
		GoToDirection();
		InMove = true;

		Vector2 Inputs = new Vector2(ForwardInput, LateralInput);
		
	//	animator.SetBool("InMove", InMove);
	//s	animator.SetFloat("Speed", Inputs.magnitude);

	}

	public void GoToDirection()
	{
		characterController.SimpleMove(direction.normalized * Speed);
	}

	public Vector3 GetForwardDirection(float InputValue)
	{
		Vector3 CameraOFfset = Vector3.Cross(camera.right,Vector3.up);

		Vector3 Direction = (CameraOFfset * InputValue);

		return Direction;
		
	}

	public Vector3 GetLateralDirection(float InputValue)
	{
		Vector3 Direction = (camera.right * InputValue);

		return Direction;
	}

	public Vector3 GetWalkingDirection()
	{
		return direction;
	}

	public void LookInWalkingDirection()
	{
		LookInDirection(GetWalkingDirection());
	}

	public void LookInDirection(Vector3 direction)
	{
		Quaternion targetRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
	}


	public void Hit(int damage)
	{
		PV -= damage;
		CheckPV();
	}

	public void CheckPV()
	{
		if(PV <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void CallDash()
	{
		Dashmovement.Dash(direction.normalized);
	}

}
