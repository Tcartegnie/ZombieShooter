﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UISlots :ItemRect,IPointerEnterHandler,IPointerExitHandler
{
	public UIInventorySlots Inventoryslots;
	public int SlotID;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Inventoryslots.SelectWeaponSlot(SlotID);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Inventoryslots.DeselectWeaponSlot();
	}

	public void SetInventorySlotsData(WeaponData data)
	{
		SetName(data.WeaponName);
		SetPicture(data.WeaponPicture);
	}
	
}
