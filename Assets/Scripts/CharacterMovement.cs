using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public float Speed;
	[SerializeField]
	Transform camera;
	[SerializeField]
	Rigidbody rb;
	public bool InMove;
	[SerializeField]
	Animator animator;
	public float DashPower;
	[SerializeField]
	CharacterShoot charactershoot;
	public int PV;
	

	public void StopMovement()
	{
		rb.velocity = Vector3.zero;
		InMove = false;
	}

	public void Walk(float ForwardInput, float LateralInput)
	{
		MoveForward(ForwardInput);
		LateralMove(LateralInput);
		InMove = true;

		Vector2 Inputs = new Vector2(ForwardInput, LateralInput);
		
		animator.SetBool("InMove", InMove);
		animator.SetFloat("Speed", Inputs.magnitude);
		
	}

	public void MoveForward(float Direction)
	{
		Vector3 CameraOFfset = Vector3.Cross(camera.right,Vector3.up);


		transform.position += CameraOFfset * ((Time.deltaTime * Speed) * Direction);
	}

	public void LateralMove(float Direction)
	{
		transform.position += camera.right * ((Time.deltaTime * Speed) * Direction);
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
		transform.rotation = Quaternion.LookRotation(direction);
	}

	public void Dash()
	{
		rb.AddForce(transform.forward * DashPower);
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

}
