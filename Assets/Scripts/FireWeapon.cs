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
 


	public void Reload()
	{
		StartCoroutine(Reloading());
	}


	public void CallShoot()
	{
		if(!OnCoolDown && weaponData.CheckAmount())
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




	IEnumerator Reloading()
	{
		characterShoot.SetReloadingTrue();
		yield return new  WaitForSeconds(weaponData.ReloadTime);
		weaponData.AddBullet(inventory.GetAmmoForReload());
		characterShoot.SetReloadingFalse();
	}

	IEnumerator ShootCoolDown()
	{
		yield return new WaitForSeconds(weaponData.CoolDown);
		OnCoolDown = false;
	}

}
