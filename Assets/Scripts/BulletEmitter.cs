using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
	/*
		- Dans l'idéal, il faudrait retiré MonoBehaviour du script
		- Passer les weapons data en paramétre de la fonction shoot ?
	 */


	public Transform Canon;
	public CharacterShoot characterShoot;

	public void Shoot(WeaponData data)
	{
		StartCoroutine(ShootBullets(data));
	}

	public void SetCanonScope(Vector3 direction)
	{
		Canon.rotation = Quaternion.LookRotation(direction);
	}

	public Vector3 GetSpreadDirection(Vector3 Spread)
	{
		Vector3 RandomSpread = new Vector3(Random.Range(Spread.x, -Spread.x), Random.Range(Spread.y, -Spread.y), 0);
		return Canon.forward + RandomSpread;
	}

	public IEnumerator ShootBullets(WeaponData data)
	{
		for (int i = 0; i < data.BulletPerShoot; i++)
		{
			GameObject currentBullet = new GameObject();
			yield return new WaitForSeconds(data.CoolDownBetweenBullet);
			SetCanonScope(characterShoot.GetShootDirection().normalized);
			currentBullet = Instantiate(data.Bullet, Canon.position, Quaternion.LookRotation(GetSpreadDirection(data.Spread)));
			
		}

	}
}
