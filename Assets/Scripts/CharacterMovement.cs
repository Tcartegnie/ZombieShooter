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
	bool InMove;
	[SerializeField]
	Animator animator;
	public float DashPower;
	[SerializeField]
	CharacterShoot charactershoot;
	public int PV;
	// Update is called once per frame
	void Update()
    {

		float ForwardInput = Input.GetAxis("Vertical");
		float LateralInput = Input.GetAxis("Horizontal");

	

		if(Input.GetMouseButtonUp(1))
		{
			Dash();
		}
		
		Vector3 movement = new Vector3(LateralInput, 0, ForwardInput);


		float InputMagnitude = new Vector3(LateralInput, ForwardInput, 0).magnitude;

		if (InputMagnitude > 0)
		{
			LateralMove(LateralInput);
			MoveForward(ForwardInput);
			GetWalkingDirection();
			InMove = true;

			if (!charactershoot.WeaponEquiped)
			{
				LookInDirection(GetWalkingDirection());
			}

		
		}
		else
		{
			rb.velocity = Vector3.zero;
			InMove = false;
		}


		animator.SetBool("InMove",InMove);
		animator.SetFloat("Speed",InputMagnitude);

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
