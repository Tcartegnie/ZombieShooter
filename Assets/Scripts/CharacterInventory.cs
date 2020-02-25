using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
	public DisplayMenuItem InventoryUI;
	public WeaponDataBase weaponDataBase;
	public CharacterShoot characterShoot;
	public UIInventorySlots slots;


	List<WeaponData> Weapons;


	public void Start()
	{
		Weapons = weaponDataBase.GetWeaponsList();
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			EquipeWeapon(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			EquipeWeapon(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			EquipeWeapon(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			EquipeWeapon(3);
		}
	}

	public void AddWeapon(WeaponData weapondata)
	{
		Weapons.Add(weapondata);
	}

	public List<WeaponData> GetWeapons()
	{
		return Weapons;
	}

	public WeaponData GetWeaponByName(string weaponName)
	{
		return Weapons.Find(weapon => weaponName == weapon.WeaponName);//Must refacto
	}


	public void EquipeWeapon(int SlotID)
	{
		if (slots.GetWeaponName(SlotID) != null)
		{
			string WeaponName = slots.GetWeaponName(SlotID);
			WeaponData data = weaponDataBase.GetWeaponByName(WeaponName);
			characterShoot.ChangeWeapon(data);
		}
		
	}

	public void TurnOnOffInventory()
	{
		InventoryUI.SetItemList(Weapons);
		InventoryUI.TurnOnOffInventory();
	}
	


}
