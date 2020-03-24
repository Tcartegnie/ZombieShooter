using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
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
	public CharacterShoot characterShoot;
	public AudioSource WeaponSound;
	public int CurrentLoadOut { get => currentLoadOut; set => currentLoadOut = value; }
	
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

	public void CallShoot()
	{
		if(!OnCoolDown && CheckAmmoCount() && !IsLoading)
		{
			OnCoolDown = true;
			bulletEmitter.Shoot(characterShoot.GetShootDirection().normalized, weaponData);
			CurrentLoadOut -= 1;
			WeaponSound.Play();
			StartCoroutine(ShootCoolDown());
			characterShoot.PlayRecoil();
			characterShoot.PlayAnimationShoot();
		}
	}
	
	public void SetWeaponData(WeaponData data)
	{
		weaponData = data;
		WeaponSound.clip = data.FireSound;
	}
	public void SetBulletEmitter(BulletEmitter bulletEmitter)
	{
		this.bulletEmitter = bulletEmitter;
	}


	public void OnBeginReloadAnimation()
	{
		IsLoading = true;
	}

	public void OnEndReloadAnimation()
	{
		IsLoading = false;
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
