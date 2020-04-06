using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float Speed;
	public float RotationSpeed;
	Vector3 direction;


	[SerializeField]
	Transform camera;
	[SerializeField]
	Animator animator;

	




	public CharacterController characterController;
	public DashMovement Dashmovement;

	public GameObject FootstepFX;
	public Transform FootstepOffset;

	public void Walk(float ForwardInput, float LateralInput)
	{
		if (ForwardInput != 0 || LateralInput != 0)
		{
			SetDirection(ForwardInput, LateralInput);
			GoToDirection();
		}
		PlayRunAnimation(ForwardInput,LateralInput);
	}

	

	public void SetDirection(float ForwardInput, float LateralInput)
	{
		direction = GetForwardDirection(ForwardInput) + GetLateralDirection(LateralInput);
	}
	
	public void SetDirection(Vector3 directionToGo)
	{
		direction = directionToGo;
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


	public void PlayRunAnimation(float ForwardInput, float LateralInput)
	{
		Vector2 Inputs = new Vector2(ForwardInput, LateralInput);
		animator.SetFloat("Speed", Inputs.magnitude);
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

	public void PlayFootstepFX()
	{
		Instantiate(FootstepFX, FootstepOffset.position,new Quaternion());
	}



	public void CallDash()
	{
		Dashmovement.Dash(direction.normalized);
	}



}
