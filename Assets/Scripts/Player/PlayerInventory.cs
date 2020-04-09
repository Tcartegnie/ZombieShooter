using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public AmmoUI AmmoUI;
	public DisplayMenuItem InventoryUI;
	public WeaponDataList weapons;
	public CharacterShoot characterShoot;
	public UIInventorySlots slots;

	public FireWeapon CurrentWeapon;

	public Transform WeaponSocket;

	List<WeaponData> Weapons;
	public GameObject CurrentInstanciedWeapon;
	public UIFXManager FXmanager;
	public Animator animator;

	public int Money;

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
			animator.SetBool("WeaponEquiped", false);
			string WeaponName = slots.GetWeaponName(slotiD);
			WeaponData data = weapons.GetWeaponByName(WeaponName);
			//characterShoot.ChangeWeapon(data);
			ChangeWeapon(data);
			AmmoUI.ChangeWeapon(CurrentWeapon);
			animator.SetInteger("WeaponTypeID",(int)data.WeaponType);
			animator.SetBool("WeaponEquiped", true);
		}
		
	}

	public FireWeapon GetCurrentWeapon()
	{
		return CurrentWeapon;
	}


	public void InstantiateWeapon(WeaponData data)//Factory ?
	{
		if (data != null)
		{
			if (CurrentInstanciedWeapon != null)
			{
				Destroy(CurrentInstanciedWeapon.gameObject);
			}
			CurrentInstanciedWeapon = Instantiate(data.WeaponModel, WeaponSocket);

			//CurrentInstanciedModel.GetComponent<BulletEmitter>();
		}
	}


	public void ChangeWeapon(WeaponData data)//Inventory ?
	{
		if (data != null)
		{
			InstantiateWeapon(data);
			CurrentWeapon.SetWeaponData(data);
			CurrentWeapon.SetBulletEmitter(CurrentInstanciedWeapon.GetComponent<BulletEmitter>());//C'est degeulasse
			CurrentInstanciedWeapon.GetComponent<BulletEmitter>().UiFxManager = FXmanager;

		}
	}


	public void GiveAmmo()//Inventory ?
	{
		SetAmmo(WeaponType.Shotgun, 60);
		SetAmmo(WeaponType.Gun, 120);
		SetAmmo(WeaponType.Rifle, 300);
	}



	public int GetCurrentAmmoQuantity()
	{
		return GetAmmoQuantity(CurrentWeapon.weaponData.WeaponType);
	}

	public int GetAmmoQuantity(WeaponType weapontype)
	{
		return BulletDictionary[weapontype];
	}

	public int GetAmmoForReload()
	{

		int totalAmmo = BulletDictionary[CurrentWeapon.weaponData.WeaponType];
		if(totalAmmo < CurrentWeapon.weaponData.LoadoutMax)
		{

			int BulletToReturn = BulletDictionary[CurrentWeapon.weaponData.WeaponType];
			BulletDictionary[CurrentWeapon.weaponData.WeaponType] = 0;

			return BulletToReturn;
		}
		else
		{
			BulletDictionary[CurrentWeapon.weaponData.WeaponType] -= CurrentWeapon.weaponData.LoadoutMax;
			return CurrentWeapon.weaponData.LoadoutMax;
		}

	}

	public void SetAmmo(WeaponType weaponname, int ammovalue)
	{
		BulletDictionary[weaponname] = ammovalue;
	}

	public void TurnOnOffInventory()
	{
		Weapons = weapons.GetBuyedWeapon();
		InventoryUI.SetItemList(Weapons);
		InventoryUI.TurnOnOffInventory();
	}

	public bool InventoryIsEneable()
	{
		return InventoryUI.MenuIsEnable();
	}

}
