using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{



	int score;
	int zombiecount;
	int money;
	int TotalScore;

	public int Score { get => score; set => score = value; }
	public int Zombiecount { get => zombiecount; set => zombiecount = value; }
	public int Money { get => money; set => money = value; }

	public static ScoreManager instance;

	public DebugUI debugUI;



	int DisplayedZombieCountKiller = 0;
	int MaxZombieCount = 0;
	public float ZombieMultiplicatorCount = 1;

	public static ScoreManager Instance()
	{
		if(instance == null)
		{
			instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
			DontDestroyOnLoad(instance);
		}
		return instance;
	}



	public void SetMaxZombieCount(int value)
	{
		MaxZombieCount = value;
	}



	public void AddCountKiller()
	{
		Zombiecount += 1;
		DisplayedZombieCountKiller += 1;
		CheckZombieCountKiller();
	}

	public void CheckZombieCountKiller()
	{
		if (Zombiecount % 5 == 0)
		{
			ZombieMultiplicatorCount += 0.5f;
		}

	}


	public void AddScore(float score)
	{
		Score += (int)(score * ZombieMultiplicatorCount);
	}

	public void AddMoney(float value)
	{
		Money += (int)(value * ZombieMultiplicatorCount);
	}


	public int ComputeScore()
	{
		int TotalScore = Score;
		TotalScore += zombiecount * 25;
		TotalScore += Money / 2;
		return TotalScore;
	}

}
