using UnityEngine;

public class LifeBar : MonoBehaviour
{
	public RectTransform Bar;


	public void SetBarValue(float RatioValue)
	{
		Bar.anchorMax = new Vector2(RatioValue, 0);
	}


}
