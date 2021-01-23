using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoystickPhone : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
	public RectTransform Centerrect;
	public Vector2 RectLenght;
	Vector2 AxisValue;
	bool IsTouched;
	int JoystickID;
	//public AudioSource DebugSound;

	public void MoveJoyStick()
	{
		transform.position = new Vector3(Centerrect.position.x + (RectLenght.x * AxisValue.x),
										Centerrect.position.y + (RectLenght.y * AxisValue.y));
	}


	 void MoveOnTouche()
	{
			Touch touch = Input.GetTouch(JoystickID);
			if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
			{
				AxisValue.x = -((Centerrect.position.x - touch.position.x) / RectLenght.x);
				AxisValue.y = -((Centerrect.position.y - touch.position.y) / RectLenght.y);

				AxisValue.y = Mathf.Clamp(AxisValue.y, -1, 1);
				AxisValue.x = Mathf.Clamp(AxisValue.x, -1, 1);
			}
	}

	public Vector3 GetDirection()
	{
		return AxisValue;
	}

    // Update is called once per frame
 


	public void GetNewTouch()
	{
		for(int i = 0; i < Input.touchCount;i++)
		{
			if(Input.GetTouch(i).phase == TouchPhase.Began)
			{
				JoystickID = i;
			}
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		IsTouched = false;
		transform.position = Centerrect.position;
		AxisValue.x = 0.0f;
		AxisValue.y = 0.0f;
	}

	IEnumerator PlayJoystick()
	{
		while(IsTouched)
		{
			MoveOnTouche();
			MoveJoyStick();
			yield return null;
		}
	//	DebugSound.Play();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		IsTouched = true;
		GetNewTouch();
		StartCoroutine(PlayJoystick());
	}
}
