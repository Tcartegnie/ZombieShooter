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
	GameObject CurrentInstanciedModel;


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
			InstantiateWeapon(data);
		}
		
	}

	public void InstantiateWeapon(WeaponData data)
	{
		if (data != null)
		{
			if (CurrentInstanciedModel != null)
			{
				Destroy(CurrentInstanciedModel.gameObject);
			}
			CurrentInstanciedModel = Instantiate(data.WeaponModel, WeaponSocket);
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
