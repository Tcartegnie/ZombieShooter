using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
	public FireWeapon CurrentWeapon;
	public PlayerInventory characterInventory;
	public Text AmmoQuantity;
	public Text AmmoQuantityMax;
	public Image WeaponPicture;

	public void Update()
	{
		DisplayAmmo();
		DisplayAmmoMax();
	}

	public void ChangeWeapon(FireWeapon weapon)
	{
		CurrentWeapon = weapon;
		ChangeWeaponPicture(weapon.weaponData.WeaponPicture);
	}

	public void ChangeWeaponPicture(Sprite WeaponPicure)
	{
		WeaponPicture.sprite = WeaponPicure;
	}
		

	public void DisplayAmmo()
	{
		AmmoQuantity.text = CurrentWeapon.weaponData.CurrentLoader + "/" + CurrentWeapon.weaponData.LoadoutMax;
	}
	
	public void DisplayAmmoMax()
	{
		AmmoQuantityMax.text = characterInventory.GetCurrentAmmoQuantity() + " / " + CurrentWeapon.weaponData.MaxAmmo;
	}

}
