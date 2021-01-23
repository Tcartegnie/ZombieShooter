using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemRect : MonoBehaviour
{
	
	public Image Picture;
	public Text ItemName;

	protected WeaponData currentweaponData;

	public string GetItemName()
	{
		return ItemName.text;
	}
	public void SetName(string name)
	{
		ItemName.text = name;
	}

	public void SetPicture(Sprite picture)
	{
		Picture.sprite = picture;
	}
}
