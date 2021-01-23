using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDropper : MonoBehaviour
{
	public GameObject MoneyPrefab;
	public Rigidbody rb;
	public float MaxStrenghMoneyExpulsion;
	public float MinStrenghMoneyExpulsion;
	public void Start()
	{
	}

	public int moneyAmmount;

	public void DropMoney()
	{
		for(int i =0;i < moneyAmmount;i++)
		{
			GameObject Coin = Instantiate(MoneyPrefab, transform.position, new Quaternion());
			rb = Coin.GetComponent<Rigidbody>();
			rb.AddForce(Vector3.up * Random.Range(MinStrenghMoneyExpulsion,MaxStrenghMoneyExpulsion));
		}
	}
}
