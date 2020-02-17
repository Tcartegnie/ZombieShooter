using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
	public int Damage;
	public float CoolDown;
	public int LoadoutMax;
	public float BulletOffset;
	public float ReloadTime;
	public int BulletPerShoot;
	public int MaxAmmo;
}
