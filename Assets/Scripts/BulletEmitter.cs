using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
	public ParticleSystem GunParicle;
	public UIFXManager UiFxManager;

	/*
		- Dans l'idéal, il faudrait retiré MonoBehaviour du script
		- Passer les weapons data en paramétre de la fonction shoot ?
	 */


	public Transform Canon;


	public void Shoot(Vector3 Direction, WeaponData data)
	{
		StartCoroutine(ShootBullets(Direction, data));
	}

	public void SetCanonScope(Vector3 direction)
	{
		Canon.rotation = Quaternion.LookRotation(direction);
		Debug.DrawRay(transform.position, direction, Color.red, Mathf.Infinity);
	}

	public Vector3 GetSpreadDirection(Vector3 Spread)
	{
		Vector3 RandomSpread = new Vector3(Random.Range(Spread.x, -Spread.x), Random.Range(Spread.y, -Spread.y), 0);
		return Canon.forward + RandomSpread;
	}


	public IEnumerator ShootBullets(Vector3 Direction,WeaponData data)
	{
		GunParicle.Play();
		UiFxManager.PlayFireFX();
		for (int i = 0; i < data.BulletPerShoot; i++)
		{
			SetCanonScope(Direction);
			GameObject currentBullet = new GameObject();
			currentBullet = Instantiate(data.Bullet, Canon.position, Quaternion.LookRotation(GetSpreadDirection(data.Spread)));
			yield return new WaitForSeconds(data.CoolDownBetweenBullet);
		}
		UiFxManager.StopFireFX();


	}

}
