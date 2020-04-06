using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{





	public AudioSource Sound;

	public Camera cam;
	[SerializeField]
	Animator animator;



	[SerializeField]
	public bool IsWeaponEquiped = false;
	[SerializeField]
	float CurrentHoldWeaponCoolDown = 0.0f;
	[SerializeField]
	float HoldWeaponCoolDown;
	// Update is called once per frame
	Vector3 ShootDirection;

	public PlayerMovement characterMovement;
	public PlayerInventory Inventory;
	public Transform WeaponSocket;
	public FireWeapon CurrentWeapon;






	public void ReloadWeapon()
	{
		ReloadCurrentWeapon();
		animator.SetTrigger("Reload");
	}

	public void ReloadCurrentWeapon()
	{
		WeaponData data = CurrentWeapon.weaponData;
		if (Inventory.GetAmmoQuantity(data.WeaponType) > 0)
		{
			Sound.PlayOneShot(Sound.clip);

			CurrentWeapon.Reload();
		}
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
		if (Inventory.CurrentInstanciedWeapon != null)
		{
			IsWeaponEquiped = true;
			animator.SetBool("WeaponEquiped", IsWeaponEquiped);
		
			CurrentHoldWeaponCoolDown = HoldWeaponCoolDown;
			TurnInShootDirection();
			CurrentWeapon.CallShoot();
			//scope.PlayScopeFX();
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
