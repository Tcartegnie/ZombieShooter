using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
	public string WeaponName;
	public WeaponType WeaponType;
	public int Damage;
	public float CoolDown;
	public int LoadoutMax;
	public float BulletOffset;
	public float ReloadTime;
	public int BulletPerShoot;
	public float CoolDownBetweenBullet;
	public int MaxAmmo;
	public Vector2 Spread;
	public GameObject Bullet;
	public Sprite WeaponPicture;
	public bool Buyed;

	public void SetWeaponAsBuyed()
	{
		Buyed = true;
	}
	
}
