using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
	public GameObject Bullet;
	public GameObject WeaponModel;
	[Space]
	public string WeaponName;
	public WeaponType WeaponType;
	public int Damage;
	public float CoolDown;
	public int LoadoutMax;
	public float ReloadTime;
	public int BulletPerShoot;
	public float CoolDownBetweenBullet;
	public int MaxAmmo;
	public Vector2 Spread;
	public Sprite WeaponPicture;
	[Space]
	public bool Buyed;
	[Space]
	public float RecoilDurantion;
	public float RecoilDistance;
	public AnimationCurve RecoilCurve;



	public void SetWeaponAsBuyed()
	{
		Buyed = true;
	}
	
}
