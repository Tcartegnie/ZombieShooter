using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponList", order = 1)]
public class WeaponDataList : ScriptableObject
{
	[SerializeField]
	List<WeaponData> WeaponsData;

	public List<WeaponData> GetAllWeaponsOfType (WeaponType weapontype)
	{
		return WeaponsData.FindAll(weapons => weapontype ==  weapons.WeaponType );
	}

	public List<WeaponData>GetAllfWeapon()
	{
		return WeaponsData;
	}

	public WeaponData GetWeaponByName(string name)
	{
		return WeaponsData.Find(weapons => name == weapons.WeaponName);
	}
}
