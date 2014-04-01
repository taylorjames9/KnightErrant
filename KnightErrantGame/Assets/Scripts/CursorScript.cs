﻿using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	public Texture2D cursorTexture;
	//public CursorMode cursorMode = CursorMode.Auto;
	//public Vector2 hotSpot = Vector2.zero;

	public int cursorSizeX  = 50;  // Your cursor size x
	public int cursorSizeY = 50;  // Your cursor size y


	/*public void OnMouseEnter () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	public void OnMouseExit () {
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}
}*/


	public void Start()
	{
		Screen.showCursor = false;
	}

	public void OnGUI()
	{
		Screen.showCursor = false;
		GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), cursorTexture);
	}
}