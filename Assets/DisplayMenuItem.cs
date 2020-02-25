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





	public void TurnOnInventory()
	{
		gameObject.SetActive(true);
	}

	public void TurnOffInventory()
	{
		gameObject.SetActive(false);
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
			gameObject.SetActive(false);
			ClearDisplay();
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
		foreach (WeaponData weapon in ItemToDisplay)
		{
			GameObject rect = new GameObject();
			rect = Instantiate(PictureRect, InventoryContent);
			UIitemInventory itemrect = rect.GetComponent<UIitemInventory>();
			itemrect.SetName(weapon.name);
			itemrect.SetPicture(weapon.WeaponPicture);
			itemrect.slots = InventorySlots;
			//	itemrect.inventory = this;
			CurrentItemInstaciated.Add(rect);
		}
	}

}
