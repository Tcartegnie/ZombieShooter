using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugWeapon : MonoBehaviour
{
	public Text AmmoText;
	public CharacterShoot CS;


	public void Update()
	{
		FireWeapon CurrentWeapon = CS.GetCurrentWeapon();
		AmmoText.text = CurrentWeapon.CurrentLoadOut + "/" + CS.GetAmmo(CurrentWeapon.weaponData.weaponName) + "\n" + CurrentWeapon.weaponData.weaponName;
	}

}
