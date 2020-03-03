using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
	public CharacterController characterController;
	public float DashDistance;
	public float DashCooldown;
	bool DashOnCoolDown;

	public void Dash(Vector3 Direction)
	{
		Debug.Log(Direction);
		if (!DashOnCoolDown)
		{
			Debug.Log(Direction * DashDistance);
			//transform.position += Direction * DashDistance; 
			characterController.SimpleMove(Direction * DashDistance);
			StartCoroutine(DashCoolDown());
		}
	}


	IEnumerator DashCoolDown()
	{
		DashOnCoolDown = true;
		for (float i = DashCooldown; i > 0; i -= Time.deltaTime)
		{
			yield return null;
		}
		DashOnCoolDown = false;
	}

}
