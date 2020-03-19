using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	public float Speed;
	[SerializeField]
	int damage;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * Speed);
    }
	//public void Update()
	//{
	//	transform.position += transform.forward * (Time.deltaTime * Speed);
	//}


	public int GetDamage()
	{
		return damage;
	}

	public void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
