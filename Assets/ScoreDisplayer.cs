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
	
	public void ScaleRect()
	{
		ScaleTransition.PlayFX();
	}

	public void HightLightRect()
	{
		ColorTransition.PlayFX();
	}
}
