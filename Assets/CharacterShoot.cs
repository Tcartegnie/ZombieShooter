using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{

	public int GunAmmo;
	public int ShotgunAmmo;
	public int RifleAmmo;

	Dictionary<WeaponType, int> BulletDictionary = new Dictionary<WeaponType, int>();

	public Camera cam;
	[SerializeField]
	Animator animator;

	public FireWeapon CurrentWeapon;
	[SerializeField]
	public bool IsWeaponEquiped = false;
	[SerializeField]
	float CurrentHoldWeaponCoolDown = 0.0f;
	[SerializeField]
	float HoldWeaponCoolDown;
	// Update is called once per frame
	WeaponType CurrentWeaponName;

	public CharacterController characterController;

	public FireWeapon GetCurrentWeapon()
	{
		return CurrentWeapon;
	}

	public void ChangeWeapon(WeaponData data)
	{
		CurrentWeapon.weaponData = data;
	}

	public void ReloadCurrentWeapon()
	{
		CurrentWeapon.Reload(BulletDictionary[CurrentWeaponName]);
	}

	public void GiveAmmo()
	{
		SetAmmo(WeaponType.Shotgun, 99999);
		SetAmmo(WeaponType.Gun, 99999);
		SetAmmo(WeaponType.Rifle, 99999);
	}

	private void Start()
	{
		characterController =GetComponent<CharacterController>();
 		BulletDictionary.Add(WeaponType.Gun,GunAmmo);
		BulletDictionary.Add(WeaponType.Shotgun,ShotgunAmmo);
		CurrentWeaponName = CurrentWeapon.weaponData.WeaponType;
		ReloadCurrentWeapon();
	}

	public int GetAmmo(WeaponType WeaponName)
	{
		return BulletDictionary[CurrentWeaponName];
	}

	public void SetAmmo(WeaponType WeaponName, int AmmoValue)
	{
		BulletDictionary[CurrentWeaponName] = AmmoValue;
	}


	public void CheckCoolDownWeaponHolding()
	{
		if(CurrentHoldWeaponCoolDown > 0)
		{
			CurrentHoldWeaponCoolDown -= Time.deltaTime;
		}
		else
		{
			IsWeaponEquiped = false;
			//animator.SetBool("WeaponEquiped", IsWeaponEquiped);
		}

	}

	public Ray GetHitOnClick()
	{
		Vector3 ScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100.0f);

		Ray ray = cam.ScreenPointToRay(ScreenPos);

		return ray;
	}

	public void Shoot()
	{

		IsWeaponEquiped = true;
		CurrentHoldWeaponCoolDown = HoldWeaponCoolDown;


		Ray ImpactPoint = GetHitOnClick();

		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(ImpactPoint, out hit))
		{

			Vector3 Direction = hit.point - transform.position;
			Direction.Normalize();
			TurnInShootDirection(Direction);
			CurrentWeapon.CallShoot(hit.point);
	
		}
//		animator.SetTrigger("Shoot");

//		animator.SetBool("WeaponEquiped", IsWeaponEquiped);

		Recoil();
	}

	public void Recoil()
	{
		Debug.Log("Test");
		characterController.Move(-transform.forward * GetCurrentWeapon().weaponData.recoil);
	}

	public void TurnInShootDirection(Vector3 Position)
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(Position.x, 0, Position.z));
	}


}
