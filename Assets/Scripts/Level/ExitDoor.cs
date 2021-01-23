using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
	public EndGameScript endGameMenu;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			endGameMenu.FadeVictory();
		}
	}
}
