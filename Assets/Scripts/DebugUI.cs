using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
	public Text zombieCount;
	public Text zombieMultiplier;
	

	public void DisplayZombieMultiplier(float value)
	{
		zombieMultiplier.text = "Zombie multiplier : " + value;
	}

	public void DisplayZombieCount(float value)
	{
		zombieCount.text = "Zombie count : " + value;
	}
}
