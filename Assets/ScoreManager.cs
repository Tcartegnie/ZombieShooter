using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	int Score;
	public Text ZombieCount;
	public ScoreDisplayer MoneyDisplay;
	public ScoreDisplayer ScoreDisplay;

	public void AddScore(int score)
	{
		Score += score;
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
		ScoreDisplay.HightLightText();
		ScoreDisplay.ScaleText();
	}

	public void DisplayMoneyCount(int moneycount)
	{
		MoneyDisplay.UpdateScore(moneycount);
		MoneyDisplay.HightLightText();
		MoneyDisplay.ScaleText();
	}

	public void DisplayZombieCount(int zombieCount)
	{
		ZombieCount.text = zombieCount.ToString();
	}


}
