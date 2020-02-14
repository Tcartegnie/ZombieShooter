using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
	[SerializeField]
	int Damage;
	[SerializeField]
	float CoolDown;
	int LoadoutMax;
	int CurrentLoadOut;
	int Ammo;
	[SerializeField]
	float BulletOffset;
	[SerializeField]
	GameObject Bullet;
	
	public int GetDamage()
	{
		return Damage;
	}

	protected void Reload()
	{
		if (LoadoutMax - CurrentLoadOut > Ammo)
		{
			CurrentLoadOut = Ammo;
			Ammo = 0;
		}
		else
		{
			CurrentLoadOut = LoadoutMax;
			Ammo -= LoadoutMax;
		}
		if(Ammo == 0)
		{
			Debug.Log("No more ammo");
		}
	}

	private bool CheckAmmoCount()
	{
		if((Ammo -1) >=0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void CallShoot(Vector3 targetPoint)
	{
		if(CheckAmmoCount())
		{
			Shoot(targetPoint);
		}
	}

	protected virtual void Shoot(Vector3 targetPoint)
	{
		//Ammo -= 1;
		//Instantiate(Bullet, transform.position + (transform.forward * BulletOffset), Quaternion.LookRotation(new Vector3(targetPoint.x, 0, targetPoint.z)));
		//transform.TransformDirection()
	}
}
