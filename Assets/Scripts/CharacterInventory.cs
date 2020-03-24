using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
	public DisplayMenuItem InventoryUI;
	public WeaponDataBase weaponDataBase;
	public CharacterShoot characterShoot;
	public UIInventorySlots slots;

	public Transform WeaponSocket;

	List<WeaponData> Weapons;
	GameObject CurrentWeapon;
//	public FireWeapon CurrentWeapon;

		
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
		Weapons = weaponDataBase.GetAllBuyedWeapon();
		InventoryUI.SetItemList(Weapons);
		InventoryUI.TurnOnOffInventory();
	}

	public bool InventoryIsEneable()
	{
		return InventoryUI.MenuIsEnable();
	}

}
