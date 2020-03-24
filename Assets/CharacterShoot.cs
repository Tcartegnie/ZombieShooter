using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{





	public AudioSource Sound;

	public Camera cam;
	[SerializeField]
	Animator animator;

	public FireWeapon CurrentWeapon;
	public GameObject CurrentInstanciedWeapon;
	[SerializeField]
	public bool IsWeaponEquiped = false;
	[SerializeField]
	float CurrentHoldWeaponCoolDown = 0.0f;
	[SerializeField]
	float HoldWeaponCoolDown;
	// Update is called once per frame
	Vector3 ShootDirection;

	public CharacterMovement characterMovement;
	public CharacterInventory Inventory;
	public Transform WeaponSocket;

	public FireWeapon GetCurrentWeapon()
	{
		return CurrentWeapon;
	}

	public void ChangeWeapon(WeaponData data)//Inventory ?
	{
		if (data != null)
		{
			InstantiateWeapon(data);
			CurrentWeapon.weaponData = data;
			CurrentWeapon.SetWeaponData(data);
			CurrentWeapon.SetBulletEmitter(CurrentInstanciedWeapon.GetComponent<BulletEmitter>());//C'est degeulasse
		}
	}


	public void InstantiateWeapon(WeaponData data)//Inventory
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


	public void ReloadCurrentWeapon()
	{
		Sound.PlayOneShot(Sound.clip );
		WeaponData data = CurrentWeapon.weaponData;
		CurrentWeapon.Reload(Inventory.GetAmmo(data.WeaponType, data.LoadoutMax));
		animator.SetTrigger("Reload");
	}



	private void Start()
	{
		ReloadCurrentWeapon();
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
		if (CurrentInstanciedWeapon != null)
		{
			IsWeaponEquiped = true;
			animator.SetBool("WeaponEquiped", IsWeaponEquiped);
		
			CurrentHoldWeaponCoolDown = HoldWeaponCoolDown;
			TurnInShootDirection();
			CurrentWeapon.CallShoot();
			
		}
	}



	public void PlayAnimationShoot()
	{
		animator.SetTrigger("Shoot");
	}


	public void TurnInShootDirection()
	{
		Vector3 ShootDirection = GetShootDirection();
		transform.rotation = Quaternion.LookRotation(new Vector3(ShootDirection.x, 0, ShootDirection.z));
		characterMovement.SetDirection(ShootDirection);
		
	}


}
