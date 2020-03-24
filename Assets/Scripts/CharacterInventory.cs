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

	Dictionary<WeaponType, int> BulletDictionary = new Dictionary<WeaponType, int>();

	public void Start()
	{
		GiveAmmo();
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

	public void EquipeWeapon(int slotiD)
	{
		if (slots.GetWeaponName(slotiD) != null)
		{
			string WeaponName = slots.GetWeaponName(slotiD);
			WeaponData data = weaponDataBase.GetWeaponByName(WeaponName);
			characterShoot.ChangeWeapon(data);
		}
		
	}

	public void GiveAmmo()//Inventory ?
	{
		SetAmmo(WeaponType.Shotgun, 99999);
		SetAmmo(WeaponType.Gun, 99999);
		SetAmmo(WeaponType.Rifle, 99999);
	}

	public int GetAmmo(WeaponType weapontype,int ammoneeded)//Inventory 
	{

		int totalAmmo = BulletDictionary[weapontype];
		if(totalAmmo > ammoneeded)
		{

			int BulletToReturn = BulletDictionary[weapontype];
			BulletDictionary[weapontype] = 0;

			return BulletToReturn;
		}
		else
		{
			BulletDictionary[weapontype] -= ammoneeded;
			return ammoneeded;
		}

	}

	public void SetAmmo(WeaponType weaponname, int ammovalue)//Inventory
	{
		BulletDictionary[weaponname] = ammovalue;
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
