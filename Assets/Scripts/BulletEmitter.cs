﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
	/*
		- Dans l'idéal, il faudrait retiré MonoBehaviour du script
		- Passer les weapons data en paramétre de la fonction shoot ?
	 */


	public Transform Canon;


	public void Shoot(WeaponData data)
	{
		StartCoroutine(ShootBullets(data));
	}

	public Vector3 GetSpreadDirection(WeaponData data)
	{
		Vector3 RandomSpread = new Vector3(Random.Range(data.BulletSpread.x, -data.BulletSpread.x), Random.Range(data.BulletSpread.y, -data.BulletSpread.y), 0);
		return Canon.forward + RandomSpread;
	}

	public IEnumerator ShootBullets(WeaponData data)
	{
		for (int i = 0; i < data.BulletPerShoot; i++)
		{
			GameObject currentBullet = new GameObject();
			yield return new WaitForSeconds(data.CoolDownBetweenBullet);
			currentBullet = Instantiate(data.Bullet, Canon.position, Quaternion.LookRotation(GetSpreadDirection(data)));
			
		}

	}
}
