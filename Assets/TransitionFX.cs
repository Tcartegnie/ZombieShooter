using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionFX : MonoBehaviour
{
	public float FxDuration;
	public abstract void PlayFXForward();
	public abstract void PlayFX();
	public abstract void RevertFX();
}
