using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
	ScoreManager ScoreManager;

	public Text text;

	public ScoreDisplayer ZombieCount;
	public ScoreDisplayer MoneyCount;
	public ScoreDisplayer ScoreCount;
	public Text ScoreMultiplier;
	int zombieMaxWave;

	

	public int ZombieMaxWave { get => zombieMaxWave; set => zombieMaxWave = value; }
	public int CurrentZombiecount { get => currentZombiecount; set => currentZombiecount = value; }

	int currentZombiecount;

	// Start is called before the first frame update
	void Start()
    {
		ScoreManager = ScoreManager.Instance();
	
	}

	public void DisplayUIData()
	{
		DisplayZombieCountOnParty();
		DisplayScoreCount();
		DisplayMoneyCount();
		DisplayMultiplicator();
	}


	public void ResetCountKiller()
	{
		CurrentZombiecount = 0;
		DisplayZombieCount();
	}



	public void DisplayZombieCount()
	{
		ZombieCount.UpdateScore(CurrentZombiecount + " / " + ZombieMaxWave);
	}


	public void DisplayMoneyCount()
	{
		MoneyCount.UpdateScore(ScoreManager.Money.ToString() + " $");
	}

	public void DisplayScoreCount()
	{
		ScoreCount.UpdateScore(ScoreManager.Score.ToString());
	}


	public void SetTextScore()
	{
		text.text = ScoreManager.ComputeScore().ToString();
	}

	public void DisplayMultiplicator()
	{
		ScoreMultiplier.text = "x" + ScoreManager.ZombieMultiplicatorCount;
	}

	public void DisplayZombieCountOnParty()
	{
		ScoreManager SM = ScoreManager.Instance();
		int TotalZombieCount = SM.Zombiecount;
		ZombieCount.UpdateScore(TotalZombieCount.ToString());
	}

}
