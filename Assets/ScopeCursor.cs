using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScopeCursor : MonoBehaviour
{
	public RectTransform CursorTransform;



	private void Start()
	{
		Cursor.visible = false;
	}
	// Update is called once per frame
	void Update()
    {
		CursorTransform.position = Input.mousePosition;
	}







}
