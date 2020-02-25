using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIitemInventory : ItemRect, IBeginDragHandler,IDragHandler, IEndDragHandler
{
	public UIInventorySlots slots;
	public void OnBeginDrag(PointerEventData eventData)
	{
		slots.SelectecWeapon(currentweaponData.WeaponName);
	}

	public void OnDrag(PointerEventData eventData)
	{
	
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		slots.SetSelectedWeapon();
	}
}
