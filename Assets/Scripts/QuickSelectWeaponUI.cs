using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class QuickSelectWeaponUI : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
	public Image ObjectPicture;
	public PlayerInventory inventory;
	public int CaseID;

	public void OnPointerDown(PointerEventData eventData)
	{
	
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		inventory.EquipeWeapon(CaseID);
	}

	public void SetPicture(Sprite picture)
	{
		ObjectPicture.sprite = picture;
	}
}
