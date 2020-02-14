using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
	public GameObject Bullet;
	public float BulletOffset;
	public Camera cam;
	public float Damage;
	[SerializeField]
	Animator animator;
	public Transform camera;
	public FireWeapon gun;

	public bool WeaponEquiped = false;
	public float CurrentHoldWeaponCoolDown = 0.0f;
	[SerializeField]
	float HoldWeaponCoolDown;
	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonUp(0))
		{
			Shoot();
		}
		CheckCoolDownWeaponHolding();

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
			gun.Shoot(hit.point);
	
		}
		animator.SetTrigger("Shoot");

		animator.SetBool("WeaponEquiped", WeaponEquiped);


	}

	public void TurnInShootDirection(Vector3 Position)
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(Position.x, 0, Position.z));
	}


}
