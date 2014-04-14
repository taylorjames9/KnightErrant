using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	public Texture2D cursorTexture;
	public Texture2D cursorTexture2;
	//public CursorMode cursorMode = CursorMode.Auto;
	//public Vector2 hotSpot = Vector2.zero;

	public static bool tappedBusPass;

	public int cursorSizeX  = 50;  // Your cursor size x
	public int cursorSizeY = 50;  // Your cursor size y

	public void Start()
	{
		Screen.showCursor = false;
	}

		/*public void OnGUI()
	{
		Screen.showCursor = false;
		
				if (GameManager.currentLiquorState == GameManager.LiquorState.GiveHimSomething && tappedBusPass) {
						print ("THE MOUSE CURSOR SHOULD BE DIFFERENT");
						GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), cursorTexture2);
				} else {
						GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), cursorTexture);
				}
	}*/
}