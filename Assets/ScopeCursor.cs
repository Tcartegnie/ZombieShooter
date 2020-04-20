using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScopeCursor : MonoBehaviour
{
	public RectTransform CursorRect;
	public RectTransform CursorTransform;
	public float CursorRadius;
	public Vector3 CursorOffset;
	public float AxisSensitivity;

	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		
	}
	// Update is called once per frame
	void Update()
    {
		//ComputeCursorPosition();
		CursorTransform.position = CursorRect.position + ((CursorOffset));
	}

	public void SetCursorPosition(Vector3 cursorPosition)
	{
		ComputeCursorPosition(cursorPosition);
	}

	 void ComputeCursorPosition(Vector3 ShootDirection)
	{
		 CursorOffset = new Vector2((ShootDirection.x * AxisSensitivity),(ShootDirection.z * (AxisSensitivity)));
		 CursorOffset = Vector3.ClampMagnitude(CursorOffset,CursorRadius);
	}

}
