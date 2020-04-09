using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFXManager : MonoBehaviour
{
	public List<TransitionFX> FireFx;

	public void PlayFireFX()
	{
		foreach(TransitionFX fx in FireFx)
		{
			fx.PlayFXForward();
		}
	}

	public void StopFireFX()
	{
		foreach (TransitionFX fx in FireFx)
		{
			fx.RevertFX();
		}
	}
}
