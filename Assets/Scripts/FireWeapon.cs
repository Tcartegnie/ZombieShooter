using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
	public int CurrentLoadOut;
	public int Ammo;
	int AmmoToFill;

	bool IsLoading;
	bool OnCoolDown;

	Vector3 BulletOffset;
	int Damage;

	[SerializeField]
	GameObject Bullet;
	[SerializeField]
	Transform Canon;
	
	public int GetDamage()
	{
		return Damage;
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			CallReload();
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			Ammo = 999999;
		}
	}

	protected void  CallReload()
	{
		if(!IsLoading)
		StartCoroutine(Reload());
	}

	protected void Reloading()
	{
		AmmoToFill  = weapondata.LoadoutMax - CurrentLoadOut;


		if ( AmmoToFill > Ammo)
		{
			CurrentLoadOut += Ammo; 
			Ammo = 0;
		}
		else
		{
			CurrentLoadOut += AmmoToFill;
			Ammo -= AmmoToFill;
		}
	}

	private bool CheckAmmoCount()
	{
		if((CurrentLoadOut - 1) >= 0)
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
		if(CheckAmmoCount() && !OnCoolDown)
		{
			OnCoolDown = true;
			Shoot(targetPoint);
			StartCoroutine(ShootCoolDown());
		}
	}

	public virtual void Shoot(Vector3 targetPoint)
	{
		CurrentLoadOut -= 1;
		Instantiate(Bullet, Canon.position + (Canon.forward * weapondata.BulletOffset), Quaternion.LookRotation(new Vector3(targetPoint.x, 0, targetPoint.z)));
		//transform.TransformDirection()
	}

	IEnumerator Reload()
	{
		yield return new  WaitForSeconds(weapondata.ReloadTime);
		Reloading();
	}

	IEnumerator ShootCoolDown()
	{
		yield return new WaitForSeconds(weapondata.CoolDown);
		OnCoolDown = false;
	}

}
