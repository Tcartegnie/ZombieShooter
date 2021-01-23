using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleTransition : TransitionFX
{
	public RectTransform RectToScale;

	public AnimationCurve GrowingAnimationcurve;
	public AnimationCurve FlatAnimationcurve;





	public IEnumerator ScaleScope(AnimationCurve curve)
	{

		for (float i = 0; i < 1; i += Time.deltaTime / FxDuration)
		{

			float curveValue = curve.Evaluate(i);

			RectToScale.localScale = new Vector3((curveValue),
													 (curveValue),
														0);


			yield return null;
		}
		float FinalcurveValue = curve.Evaluate(1);

		RectToScale.localScale = new Vector3((FinalcurveValue),
												 (FinalcurveValue),
													0);

	}


	public IEnumerator GrowTheScope()
	{
		yield return StartCoroutine(ScaleScope(GrowingAnimationcurve));
	}

	public IEnumerator FlatTheScope()
	{
		yield return StartCoroutine(ScaleScope(FlatAnimationcurve));

	}

	public IEnumerator ScopeShootFX()
	{
		yield return StartCoroutine(GrowTheScope());
		yield return StartCoroutine(FlatTheScope());
	}

	public override void PlayFXForward()
	{

		StartCoroutine(GrowTheScope());
	}

	public override void RevertFX()
	{
		StartCoroutine(FlatTheScope());

	}

	public override void PlayFX()
	{
		StartCoroutine(ScopeShootFX());
	}
}
