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
	public float DashDuration;
	public float Dashdistance;
	public float DashPower;
	[SerializeField]
	CharacterShoot charactershoot;
	public int PV;
	public float RotationSpeed;
	

	public void StopMovement()
	{
		InMove = false;
	}

	public void Walk(float ForwardInput, float LateralInput)
	{
		Vector3 Direction = MoveForward(ForwardInput) + LateralMove(LateralInput);

		Direction.Normalize();



		GoToDirection(Direction);


		InMove = true;

		Vector2 Inputs = new Vector2(ForwardInput, LateralInput);
		
		animator.SetBool("InMove", InMove);
		animator.SetFloat("Speed", Inputs.magnitude);

	}

	public void GoToDirection(Vector3 direction)
	{
		transform.position += direction * (Time.deltaTime * Speed);
	}

	public Vector3 MoveForward(float InputValue)
	{
		Vector3 CameraOFfset = Vector3.Cross(camera.right,Vector3.up);

		Vector3 Direction = (CameraOFfset * InputValue);

		return Direction;
		
	}

	public Vector3 LateralMove(float InputValue)
	{
		Vector3 Direction = (camera.right * InputValue);

		return Direction;
	}

	public Vector3 GetWalkingDirection()
	{
		Vector3 ForwardDirection = (Vector3.Cross(camera.right, Vector3.up)) * Input.GetAxis("Vertical");
		Vector3 LeftDirection = camera.right * Input.GetAxis("Horizontal");
		Vector3 Dircection = ForwardDirection + LeftDirection;
		return Dircection;
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

	public void Dash()
	{
		Vector3 PointToDash = transform.forward * Dashdistance;

		StartCoroutine(Dash(transform.position + PointToDash));
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

	public IEnumerator Dash(Vector3 PointToDash)
	{
		Vector3 StartPosition = transform.position;
		for(float i = 0; i < 1; i+= (Time.deltaTime / DashDuration))
		{
			transform.position = (Vector3.Lerp(StartPosition, PointToDash,i));
			yield return null;
		}
	}

}
