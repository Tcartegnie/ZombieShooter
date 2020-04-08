using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float Speed;
	public float RotationSpeed;
	Vector3 WalkingDirection;


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

	public void SetAnimationDirection(Vector2 Direction)
	{
		animator.SetFloat("HorizontalStrafe", Direction.x);
		animator.SetFloat("VerticalStrafe", Direction.y);
	}

	public void SetDirection(float ForwardInput, float LateralInput)
	{
		WalkingDirection = GetForwardDirection(ForwardInput) + GetLateralDirection(LateralInput);
	}
	
	public void SetDirection(Vector3 directionToGo)
	{
		WalkingDirection = directionToGo;
	}
	public void GoToDirection()
	{
		characterController.SimpleMove(WalkingDirection.normalized * Speed);
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
		return WalkingDirection;
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
		Dashmovement.Dash(WalkingDirection.normalized);
	}



}
