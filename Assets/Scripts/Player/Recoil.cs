using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

	public CharacterController characterController;


	public void PlayRecoil(WeaponData data)
	{
		StartCoroutine(ShootRecoil(data));
	}

	IEnumerator ShootRecoil(WeaponData data)
	{
		
		float NormalizedDistanceOfRecoil = (data.RecoilDistance / data.RecoilDurantion);
		for (float t = 0; t < data.RecoilDurantion; t += Time.deltaTime)
		{
			yield return null;
			characterController.Move(-transform.forward * (NormalizedDistanceOfRecoil * Time.deltaTime) * data.RecoilCurve.Evaluate(t));
		}
	}
}
