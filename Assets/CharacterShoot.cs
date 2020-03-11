using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{

	public int GunAmmo;
	public int ShotgunAmmo;
	public int RifleAmmo;

	Dictionary<WeaponType, int> BulletDictionary = new Dictionary<WeaponType, int>();

	public AudioSource Sound;

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
	Vector3 ShootDirection;

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
		Sound.Play();
		CurrentWeapon.Reload(BulletDictionary[CurrentWeaponName]);
		animator.SetTrigger("Reload");
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

	public void Update()
	{
	}

	public Vector3 GetShootDirection()
	{
		Ray ImpactPoint = GetHitOnClick();

		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(ImpactPoint, out hit))
		{
			Vector3 direction = hit.point - transform.position;
			ShootDirection = new Vector3(direction.x, 0, direction.z);
			return ShootDirection;
		}
		return new Vector3();
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
			animator.SetBool("WeaponEquiped", IsWeaponEquiped);
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
		animator.SetBool("WeaponEquiped", IsWeaponEquiped);
		CurrentHoldWeaponCoolDown = HoldWeaponCoolDown;
		TurnInShootDirection(GetShootDirection().normalized);
		CurrentWeapon.CallShoot();
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
