using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
	Gun,
	Rifle,
	Shotgun,

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
	public Recoil Recoil;
	public PlayerInventory inventory;
	public int CurrentLoadOut { get => currentLoadOut; set => currentLoadOut = value; }
 


	public void Reload()
	{
		if(!IsLoading)
		StartCoroutine(Reloading());
	}


	private bool CheckAmmoCount()
	{
		if((weaponData.CurrentLoader -1) >= 0)
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
			weaponData.LostBullets(1);
			WeaponSound.Play();
			StartCoroutine(ShootCoolDown());
			Recoil.PlayRecoil(weaponData);
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
		//IsLoading = true;
	}

	public void OnEndReloadAnimation()
	{
		//IsLoading = false;
	}

	IEnumerator Reloading()
	{
		IsLoading = true;
		yield return new  WaitForSeconds(weaponData.ReloadTime);
		weaponData.AddBullet(inventory.GetAmmoForReload());
		IsLoading = false;
	}

	IEnumerator ShootCoolDown()
	{
		yield return new WaitForSeconds(weaponData.CoolDown);
		OnCoolDown = false;
	}

}
