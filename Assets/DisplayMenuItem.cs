using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenuItem : MonoBehaviour
{
	public GameObject PictureRect;
	public RectTransform InventoryContent;
	public UIInventorySlots InventorySlots;
	List<WeaponData> ItemToDisplay = new List<WeaponData>();
	protected List<GameObject> CurrentItemInstaciated = new List<GameObject>();
	bool IsEneable;




	public void TurnOnInventory()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		gameObject.SetActive(true);
		IsEneable = true;
	}

	public void TurnOffInventory()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		gameObject.SetActive(false);
		IsEneable = false;
	}

	public void TurnOnOffInventory()
	{
		if(!gameObject.activeInHierarchy)
		{
			TurnOnInventory();
			DisplayItemList();
		}
		else
		{
			TurnOffInventory();
		}
	
	}

	public void ClearDisplay()//OtherScript
	{
		foreach (GameObject weapon in CurrentItemInstaciated)
		{
			Destroy(weapon);
		}
		CurrentItemInstaciated.Clear();
	}

	public void SetItemList(List<WeaponData>items)
	{
		ItemToDisplay = items;
	}

	public void DisplayItemList()
	{
		ClearDisplay();
		foreach (WeaponData weapon in ItemToDisplay)
		{
			GameObject rect = new GameObject();
			rect = Instantiate(PictureRect, InventoryContent);
			UIitemInventory itemrect = rect.GetComponent<UIitemInventory>();
			itemrect.SetName(weapon.WeaponName);
			itemrect.SetPicture(weapon.WeaponPicture);
			itemrect.slots = InventorySlots;
			//	itemrect.inventory = this;
			CurrentItemInstaciated.Add(rect);
		}
	}

	public bool MenuIsEnable()
	{
		return IsEneable;
	}

}
