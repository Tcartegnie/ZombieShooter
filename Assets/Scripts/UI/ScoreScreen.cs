using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
	ScoreManager SM;
	public Text ScoreText;
	public ScoreUI scoreUI;

	// Start is called before the first frame update
	void Start()
    {
		SM = ScoreManager.Instance();
		ScoreText.text = SM.ComputeScore().ToString();
		scoreUI.DisplayUIData();
    }


	public void OnMainMenuButton()
	{
		SceneManager.LoadScene(1);
	}

	public void OnGoToQG()
	{
		SceneManager.LoadScene(1);
	}
	
}
