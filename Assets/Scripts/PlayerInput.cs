﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public CharacterMovement PlayerMovement;
	public CharacterShoot PlayerShoot;
	public CharacterInventory CharacterInventory;
	float ForwardInput;
	float LateralInput;
	// Update is called once per frame
	void Update()
    {
		CheckMovementInput();
		CheckShootInput();
		CheckInventoryInput();
    }

	void CheckShootInput()
	{
		PlayerShoot.CheckCoolDownWeaponHolding();

		if (Input.GetMouseButtonUp(0))
		{
			PlayerShoot.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerShoot.ReloadCurrentWeapon();
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			PlayerShoot.GiveAmmo();
		}

	}

	void CheckMovementInput()
	{
		ForwardInput = Input.GetAxis("Vertical");
		LateralInput = Input.GetAxis("Horizontal");

		if(ForwardInput != 0 || LateralInput != 0)
		{
			PlayerMovement.Walk(ForwardInput,LateralInput);
	
			if (!PlayerShoot.IsWeaponEquiped)
			{
				PlayerMovement.LookInWalkingDirection();
			}
		}
		else
		{
			PlayerMovement.StopMovement();
		}

		if (Input.GetMouseButtonUp(1))
		{
			PlayerMovement.Dash();
		}

	}

	void CheckInventoryInput()
	{
		if(Input.GetKeyUp(KeyCode.I))
		{
			CharacterInventory.TurnOnOffInventory();
		}
	}

}