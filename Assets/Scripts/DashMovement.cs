using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
	public DashMovement dash;
	public CharacterController characterController;
	public float DashDuration;
	public float DashPower;
	public float DashCooldown;
	bool DashOnCoolDown;

	public IEnumerator Dash(Vector3 Direction)
	{
		if (!DashOnCoolDown)
		{
			for (float i = 0; i < 1; i += Time.deltaTime / DashDuration)
			{
				characterController.SimpleMove(Direction * DashPower);
				yield return null;
			}
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
