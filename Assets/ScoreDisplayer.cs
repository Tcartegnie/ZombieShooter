using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
	public Text text;
	public ScaleTransition ScaleTransition;
	public ColorTranstion ColorTransition;
   public void UpdateScore(int score)
	{
		text.text = score.ToString();
	}
	
	public void HightLightText()
	{
		ScaleTransition.PlayFX();
	}

	public void ScaleText()
	{
		ColorTransition.PlayFX();
	}
}
