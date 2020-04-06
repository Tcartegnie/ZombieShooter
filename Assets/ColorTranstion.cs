using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTranstion : TransitionFX
{
	

	public Image Scope;

	public Color ScopeBaseColor;
	public Color ScopeShootColor;



	public IEnumerator ColorTransition(Color ColorToFade)
	{
		Color color = new Color();
		color =	Scope.color;
		for (float i = 0; i < 1; i += Time.deltaTime / FxDuration)
		{

			Scope.color = Color.Lerp(color, ColorToFade, i);


			yield return null;
		}
		Scope.color = ColorToFade;
	}

	public IEnumerator TransitToFXcolor()
	{
		yield return StartCoroutine(ColorTransition(ScopeShootColor));
	}

	public IEnumerator TransitToBasicColor()
	{
		yield return StartCoroutine(ColorTransition(ScopeBaseColor));

	}

	public IEnumerator ScopeShootFX()
	{
		yield return StartCoroutine(TransitToFXcolor());
		yield return StartCoroutine(TransitToBasicColor());
	}

	public override void PlayFX()
	{
		StartCoroutine(TransitToFXcolor());
	}

	public override void RevertFX()
	{
		StartCoroutine(TransitToBasicColor());
	}
}
