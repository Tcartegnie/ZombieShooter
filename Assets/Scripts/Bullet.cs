using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	public float Speed;
	public int BulletStrenght;
	[SerializeField]
	int damage;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * Speed);
    }


	public int GetDamage()
	{
		return damage;
	}
	public void SetDamage(int value)
	{
		damage = value;
	}
	public void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}

	public void OnHit()
	{
		BulletStrenght -= 1;
		CheckStrengh();
	}

	public void CheckStrengh()
	{
		if(BulletStrenght == 0)
		{
			Destroy(gameObject);
		}
	}
}
