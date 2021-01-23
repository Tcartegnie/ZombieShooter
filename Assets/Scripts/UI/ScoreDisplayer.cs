using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
	public Text text;
	public ScaleTransition ScaleTransition;
	public ColorTranstion ColorTransition;

	public void Update()
	{
		
	}

	public void UpdateScore(string scoreText)
	{
		text.text = scoreText;
		ScaleRect();
		HightLightRect();
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
