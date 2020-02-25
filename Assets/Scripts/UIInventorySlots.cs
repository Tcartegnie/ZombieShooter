using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIInventorySlots : MonoBehaviour
{

	public WeaponDataBase weaponDataBase;
	public List<UISlots> WeaponSlots = new List<UISlots>();

	int SlotID;

	string SelectedWeaponName;

	

	public void SetSelectedWeapon()//Logique//MenuInventaire
	{
		if (SlotID < WeaponSlots.Count && SlotID >= 0)
		{
			WeaponData weapon = weaponDataBase.GetWeaponByName(SelectedWeaponName);
			WeaponSlots[SlotID].SetInventorySlotsData(weapon);
		}
	}

	public void SelectecWeapon(string WeaponName)
	{
		SelectedWeaponName = WeaponName;
	}

	public string GetWeaponName(int SlotID)
	{
		return WeaponSlots[SlotID].GetItemName();
	}

	public void DeselectWeaponSlot()//Logique//MenuInventaire
	{
		SlotID = WeaponSlots.Count + 1;
	}

	public void SelectWeaponSlot(int slotID)//Logique//MenuInventaire
	{
		SlotID = slotID;
	}

}
