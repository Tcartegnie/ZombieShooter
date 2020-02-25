using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataBase : MonoBehaviour
{
	public WeaponDataList weaponDataList;
	


	public List<WeaponData> GetWeaponsList()
	{
		return weaponDataList.GetAllfWeapon();
	}

	public WeaponData GetWeaponByName(string name)
	{
		return weaponDataList.GetWeaponByName(name);
	}
}
