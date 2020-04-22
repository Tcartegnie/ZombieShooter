using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
	NoWeaopn = -1,
	Gun,
	Rifle,
	Shotgun,
	Carabine

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
 


	public void Reload(float ReloadTime)
	{
		StartCoroutine(Reloading(ReloadTime));
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
			characterShoot.PlayAnimationShoot();
			OnCoolDown = true;
			bulletEmitter.Shoot(-characterShoot.GetShootDirection(), weaponData);
			weaponData.LostBullets(1);
			WeaponSound.Play();
			StartCoroutine(ShootCoolDown());
			Recoil.PlayRecoil(weaponData);
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




	IEnumerator Reloading(float reloadTime)
	{
		IsLoading = true;
		yield return new  WaitForSeconds(reloadTime);
		weaponData.AddBullet(inventory.GetAmmoForReload());
		IsLoading = false;
	}

	IEnumerator ShootCoolDown()
	{
		yield return new WaitForSeconds(weaponData.CoolDown);
		OnCoolDown = false;
	}

}
