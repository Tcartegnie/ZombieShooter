using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
	public WeaponName weaponName;
	public int Damage;
	public float CoolDown;
	public int LoadoutMax;
	public float BulletOffset;
	public float ReloadTime;
	public int BulletPerShoot;
	public float CoolDownBetweenBullet;
	public int MaxAmmo;
	public Vector2 BulletSpread;
	public GameObject Bullet;
}
