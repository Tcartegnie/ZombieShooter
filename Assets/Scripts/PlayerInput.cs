using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public PlayerMovement PlayerMovement;
	public CharacterShoot PlayerShoot;
	public PlayerInventory CharacterInventory;
	public WeaponShop Shop;
	float ForwardInput;
	float LateralInput;
	// Update is called once per frame
	void Update()
    {
		if (!CharacterInventory.InventoryIsEneable())
		{
			CheckMovementInput();
			CheckShootInput();
		}
			CheckInventoryInput();
    }

	void CheckShootInput()
	{
		PlayerShoot.CheckCoolDownWeaponHolding();
		if (Input.GetMouseButtonUp(0))
		{
			PlayerShoot.Shoot();
		}

		if (Input.GetKeyUp(KeyCode.R))
		{
			PlayerShoot.ReloadCurrentWeapon();
		}

		if (Input.GetKeyUp(KeyCode.A))
		{
			CharacterInventory.HoldWeapon();
		}

	}

	void CheckMovementInput()
	{
		ForwardInput = Input.GetAxis("Vertical");
		LateralInput = Input.GetAxis("Horizontal");

		PlayerMovement.Walk(ForwardInput,LateralInput);
	
		if (!PlayerShoot.IsWeaponEquiped)
		{
			PlayerMovement.LookInWalkingDirection();
		}

		if (Input.GetMouseButtonUp(1))
		{
			PlayerMovement.CallDash();
		}

	}

	void CheckInventoryInput()
	{
		if(Input.GetKeyUp(KeyCode.I))
		{
			CharacterInventory.TurnOnOffInventory();
		}

		if (Input.GetKeyUp(KeyCode.J))
		{
			Shop.TurnOnOffShop();
		}
		
	}



}
