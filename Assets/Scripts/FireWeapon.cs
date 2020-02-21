using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName
{
	Gun,
	Shotgun,
	Rifle
}
public class FireWeapon : MonoBehaviour
{

	//public WeaponName WeaponName;

	int currentLoadOut;
	//public int MaxLoadOut;
	int AmmoToFill;

	bool IsLoading;
	bool OnCoolDown;
	//public float ReloadTime;
	//public float CoolDownShoot;

	public WeaponData weaponData;
	public BulletEmitter bulletEmitter;

	public int CurrentLoadOut { get => currentLoadOut; set => currentLoadOut = value; }

	//public int GetDamage()
	//{
	//	return Damage;
	//}

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
		AmmoToFill  =  weaponData.LoadoutMax - CurrentLoadOut;


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
		if(!OnCoolDown && CheckAmmoCount())
		{
			OnCoolDown = true;
			//	Shoot(targetPoint);
			bulletEmitter.Shoot(weaponData);
			CurrentLoadOut -= 1;
			StartCoroutine(ShootCoolDown());
		}

	
	}

	public virtual void Shoot()
	{
		//CurrentLoadOut -= 1;
		//Instantiate(Bullet, Canon.position + (BulletOffset), Quaternion.LookRotation(new Vector3(DirectionToSHoot.x + targetPoint.x, DirectionToSHoot.y, DirectionToSHoot.z + targetPoint.z)));
		//transform.TransformDirection()
	}

	IEnumerator Reloading(int ammo)
	{
		yield return new  WaitForSeconds(weaponData.ReloadTime);
		PutAmmo(ammo);
	}

	IEnumerator ShootCoolDown()
	{
		yield return new WaitForSeconds(weaponData.CoolDown);
		OnCoolDown = false;
	}

}
