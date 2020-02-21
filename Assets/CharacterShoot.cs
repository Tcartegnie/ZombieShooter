using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{

	public int GunAmmo;
	public int ShotgunAmmo;
	public int RifleAmmo;

	Dictionary<WeaponName, int> BulletDictionary = new Dictionary<WeaponName, int>();

	public Camera cam;
	[SerializeField]
	Animator animator;

	public List<FireWeapon> Weapons;

	public FireWeapon CurrentWeapon;
	[SerializeField]
	public bool WeaponEquiped = false;
	[SerializeField]
	float CurrentHoldWeaponCoolDown = 0.0f;
	[SerializeField]
	float HoldWeaponCoolDown;
	// Update is called once per frame
	WeaponName CurrentWeaponName;

	public FireWeapon GetCurrentWeapon()
	{
		return CurrentWeapon;
	}

	private void Start()
	{
 		BulletDictionary.Add(WeaponName.Gun,GunAmmo);
		BulletDictionary.Add(WeaponName.Shotgun,ShotgunAmmo);
		CurrentWeaponName = CurrentWeapon.weaponData.weaponName;
	}

	public int GetAmmo(WeaponName WeaponName)
	{
		return BulletDictionary[CurrentWeaponName];
	}

	public void SetAmmo(WeaponName WeaponName, int AmmoValue)
	{
		BulletDictionary[CurrentWeaponName] = AmmoValue;
	}

	void Update()
    {
		CheckCoolDownWeaponHolding();

		if (Input.GetMouseButtonUp(0))
		{
			Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			CurrentWeapon.Reload(BulletDictionary[CurrentWeaponName]);
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			SetAmmo(CurrentWeaponName, 99999);
		}

	}
	public void CheckCoolDownWeaponHolding()
	{
		if(CurrentHoldWeaponCoolDown > 0)
		{
			CurrentHoldWeaponCoolDown -= Time.deltaTime;
		}
		else
		{
			WeaponEquiped = false;
			animator.SetBool("WeaponEquiped", WeaponEquiped);
		}

	}

	void Shoot()
	{

		WeaponEquiped = true;
		CurrentHoldWeaponCoolDown = HoldWeaponCoolDown;


		Vector3 ScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100.0f);

		Ray ImpactPoint = cam.ScreenPointToRay(ScreenPos);

		RaycastHit hit = new RaycastHit();


		if (Physics.Raycast(ImpactPoint, out hit))
		{

			Vector3 Direction = hit.point - transform.position;
			Direction.Normalize();
			TurnInShootDirection(Direction);
			CurrentWeapon.CallShoot(hit.point);
	
		}
		animator.SetTrigger("Shoot");

		animator.SetBool("WeaponEquiped", WeaponEquiped);


	}

	public void TurnInShootDirection(Vector3 Position)
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(Position.x, 0, Position.z));
	}


}
