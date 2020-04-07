using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
	public Text EndGameText;

	public Button TryAgaine;
	public Button Continue;
	public Button ReturnToMainMenu;

	public string VictoryText;
	public string GameOverText;

	public float FadeTime;
	public Image EndGamePicture;
	public GameObject EndGameRect;
	public PlayerStatistique playerStatistique;
	private void Start()
	{
		//FadeVictory();
		playerStatistique.ondeath += FadeGameOver;
	}

	public void SetEndGameText(string text)
	{
		EndGameText.text = text;
	}


	public void OnTryAgainPressed()
	{
		SceneManager.LoadScene(2);
	}

	public void OnContinuePressed()
	{

	}

	public void OnReturnToMainMenu()
	{
		SceneManager.LoadScene(1);
	}

	public void SetVictoryText()
	{
		SetEndGameText(VictoryText);
	}

	public void SetGameOverText()
	{
		SetEndGameText(GameOverText);
	}


	public void FadeVictory()
	{
		SetVictoryText();
		StartCoroutine(FadeEndGame());
	}

	public void FadeGameOver()
	{
		SetGameOverText();
		StartCoroutine(FadeEndGame());
	}

	IEnumerator FadeEndGame()
	{
		EndGameRect.SetActive(true);
		for (float time = 0.0f; time < 1; time += Time.deltaTime / FadeTime)
		{
			EndGamePicture.color = new Color(0, 0, 0, time);
			Color color = EndGameText.color;
			EndGameText.color = new Color(color.a, color.b, color.g, time);
			yield return null;
		}
		
		EndGamePicture.CrossFadeAlpha(1, FadeTime, false);
		EndGameText.CrossFadeAlpha(1, FadeTime, false);

		TryAgaine.gameObject.SetActive(true);
		Continue.gameObject.SetActive(true);
		ReturnToMainMenu.gameObject.SetActive(true);
		Cursor.visible = true;
		//Time.timeScale = 0;
	}


}
