using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public DebugUI debugUI;

	int Score;
	public Text ZombieCount;
	public Text ScoreMultiplicator;
	public ScoreDisplayer MoneyDisplay;
	public ScoreDisplayer ScoreDisplay;

	int ZombieCountKiller = 0;
	float ZombieMultiplicatorCount = 1;

	public void Start()
	{
		DisplayZombieCount();
		DisplayMultiplicator();
	}

	public void AddCountKiller()
	{
		ZombieCountKiller += 1;
		debugUI.DisplayZombieCount(ZombieCountKiller);
		CheckZombieCountKiller();
		DisplayZombieCount();
	}

	public void CheckZombieCountKiller()
	{
		if(ZombieCountKiller % 5 == 0)
		{
			ZombieMultiplicatorCount += 0.5f;
			DisplayMultiplicator();
		}

	}

	public void AddScore(float score)
	{
		Score += (int)(score * ZombieMultiplicatorCount);
	}

	public int GetScore()
	{
		return Score;
	}

	public void UpdateScore()
	{
		DisplayScore(GetScore());
	}


	public void DisplayScore(int moneycount)
	{
		ScoreDisplay.UpdateScore(moneycount);
		ScoreDisplay.HightLightRect();
		ScoreDisplay.ScaleRect();
	}

	public void DisplayMoneyCount(int moneycount)
	{
		MoneyDisplay.UpdateScore(moneycount);
		MoneyDisplay.HightLightRect();
		MoneyDisplay.ScaleRect();
	}

	public void DisplayZombieCount()
	{
		ZombieCount.text = ZombieCountKiller + "/" + Mathf.Infinity;
	}

	public void DisplayMultiplicator()
	{
		ScoreMultiplicator.text = "x" + ZombieMultiplicatorCount;
	}

}
