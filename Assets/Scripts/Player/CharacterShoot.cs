using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{




	public bool IsWeaponReloading;
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
	public ScopeCursor cursor;
	Vector3 ShootOffset = new Vector3(0,0,0);
	public Vector2 AxisSensitivity;
	public JoystickPhone ShootJoyStick;

	public void Update()
	{  
		cursor.SetCursorPosition(GetShootDirection());
	}


	float GetMousePosX()
	{
		return Input.GetAxis("Mouse X");
	}

	float GetMousePosY()
	{
		return Input.GetAxis("Mouse Y");
	}


	

	public void ReloadWeapon()
	{
		animator.SetTrigger("Reload");
	}

	public void ReloadCurrentWeapon()
	{
	
		WeaponData data = CurrentWeapon.weaponData;
		if (Inventory.GetAmmoQuantity(data.WeaponType) > 0)
		{
			ReloadWeapon();
			Sound.PlayOneShot(Sound.clip);
			CurrentWeapon.Reload();
		}
	}


	public Vector3 GetShootDirection()
	{

//#if UNITY_PC || UNITY_EDITOR
		return GetShootDirectionOnPC();
//#elif UNITY_ANDROID
	//	return GetShootDirectionOnMobile();
//#endif
	}

	public Vector3 GetShootDirectionOnPC()
	{
		//ShootOffset = ShootJoyStick.GetDirection();
		ShootOffset += new Vector3(GetMousePosX() * AxisSensitivity.x, 0, GetMousePosY() * AxisSensitivity.y);
		ShootOffset = Vector3.ClampMagnitude(ShootOffset, 1);
		return ShootOffset;
	}

	public Vector3 GetShootDirectionOnMobile()
	{
		ShootOffset = new Vector3(ShootJoyStick.GetDirection().x,0, ShootJoyStick.GetDirection().y);
		ShootOffset = Vector3.ClampMagnitude(ShootOffset, 1);
		return ShootOffset;
	}

	public Vector3 GetTargetDirection(Vector3 targetPosition)
	{
		Vector3 direction = targetPosition - transform.position;
		ShootDirection = new Vector3(direction.x, 0, direction.z);
		return ShootDirection;
	}



	public void CheckCoolDownWeaponHolding()
	{
		if(CurrentHoldWeaponCoolDown >= 0)
		{
			CurrentHoldWeaponCoolDown -= Time.deltaTime;
			animator.SetFloat("WeaponStandTime", CurrentHoldWeaponCoolDown);
		}
		else
		{
			IsWeaponEquiped = false;
			//animator.SetBool("WeaponEquiped", IsWeaponEquiped);
		}

	}


	public void Shoot()
	{
		if (Inventory.CurrentInstanciedWeapon != null && !IsWeaponReloading)
		{
			IsWeaponEquiped = true;
			//animator.SetBool("WeaponEquiped", IsWeaponEquiped);
		
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
		Vector3 ShootDirection = -GetShootDirection();
		Debug.DrawRay(transform.position,ShootDirection, Color.red);
		transform.rotation = Quaternion.LookRotation(new Vector3(ShootDirection.x, 0, ShootDirection.z));
		characterMovement.SetDirection(ShootDirection);
		
	}

	public void SetReloadingTrue()
	{
		IsWeaponReloading = true;
	}
	public void SetReloadingFalse()
	{
		IsWeaponReloading = false;
	}
}
