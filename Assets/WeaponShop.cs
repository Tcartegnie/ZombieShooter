using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
	public UIInventorySlots inventorySlots;
	public DisplayMenuItem menuItem;
	public WeaponDataBase weaponDataBase;
	
	public void TurnOnSHop()
	{
		List<WeaponData> weapons = weaponDataBase.GetWeaponsList();
		menuItem.TurnOnInventory();
		menuItem.SetItemList(weapons);
		menuItem.DisplayItemList();
	}

	public void OnButtonSellPressed()
	{
		weaponDataBase.GetWeaponByName(inventorySlots.GetWeaponName(0)).SetWeaponAsBuyed();
	}

	public void OnButtonSellAnnulationPressed()
	{

	}

	public void TurnOffShop()
	{
		menuItem.TurnOffInventory();
	}


}
