using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInput : MonoBehaviour
{
	public PlayerMovement PlayerMovement;
	public CharacterShoot PlayerShoot;
	public PlayerInventory CharacterInventory;
	public WeaponShop Shop;
	public RectTransform CenterJoystickPosition;
	public JoystickPhone joyStick;
	public JoystickPhone ShootjoyStick;
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


	if (ShootjoyStick.GetDirection().magnitude > 0.2)
	{
			PlayerShoot.Shoot();
	}

		if (Input.GetMouseButtonUp(0))
		{
			PlayerShoot.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerShoot.ReloadWeapon();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			CharacterInventory.HoldWeapon();
		}

	}


	void CheckMovementInput()
	{
		ForwardInput = Input.GetAxis("Vertical");
		LateralInput = Input.GetAxis("Horizontal");

	


#if UNITY_ANDROID
		//MoveOnTouch();
		LateralInput = joyStick.GetDirection().x;
		ForwardInput = joyStick.GetDirection().y;
#endif

		PlayerMovement.Walk(ForwardInput, LateralInput);

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
