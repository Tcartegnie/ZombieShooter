using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

	public string WeaponName;

	public int CurrentLoadOut;
	public int MaxLoadOut;
	int AmmoToFill;

	bool IsLoading;
	bool OnCoolDown;
	public float ReloadTime;
	public float CoolDownShoot;



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
	
	}

	public void Reload(int ammo)
	{
		if(!IsLoading)
		StartCoroutine(Reloading(ammo));
	}

	protected void PutAmmo(int ammo)
	{
		AmmoToFill  = MaxLoadOut - CurrentLoadOut;


		if ( AmmoToFill > ammo)
		{
			CurrentLoadOut += ammo;
			ammo = 0;
		}
		else
		{
			CurrentLoadOut += AmmoToFill;
			ammo -= AmmoToFill;
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

	public virtual void Shoot(Vector3 targetPoint, Vector3 DirectionToSHoot)
	{
		CurrentLoadOut -= 1;
		Instantiate(Bullet, Canon.position + (BulletOffset), Quaternion.LookRotation(new Vector3(DirectionToSHoot.x + targetPoint.x, DirectionToSHoot.y, DirectionToSHoot.z + targetPoint.z)));
		//transform.TransformDirection()
	}

	IEnumerator Reloading(int ammo)
	{
		yield return new  WaitForSeconds(ReloadTime);
		PutAmmo(ammo);
	}

	IEnumerator ShootCoolDown()
	{
		yield return new WaitForSeconds(CoolDownShoot);
		OnCoolDown = false;
	}

}
