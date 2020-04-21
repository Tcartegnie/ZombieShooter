using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoot : MonoBehaviour
{
	public PlayerInventory inventory;
	public float ObjectLootSpeed;
	public AudioSource SoundPlayer;

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Money")
		{
			StartCoroutine(CallLoot(other.GetComponent<Money>()));
		}
	}

	public IEnumerator CallLoot(Money Loot)
	{
		yield return StartCoroutine(TransitObjectToTarget(Loot.transform));
		inventory.AddMoney(Loot.Value);
	}


	public IEnumerator TransitObjectToTarget(Transform loot)
	{
		Vector3 OriginalPosition = loot.position;
		for (float i = 0; i < 1; i += Time.deltaTime / ObjectLootSpeed)
		{
			yield return null;
			loot.position = Vector3.Lerp(OriginalPosition, transform.position, i);
		}
		SoundPlayer.PlayOneShot(loot.GetComponent<Money>().GetDropSound());
		Destroy(loot.gameObject);
			
	}
}
