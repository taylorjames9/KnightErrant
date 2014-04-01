using UnityEngine;
using System.Collections;

public class CameraCursorScript : MonoBehaviour {

	public Texture2D cursorTexture;
	//public CursorMode cursorMode = CursorMode.Auto;
	//public Vector2 hotSpot = Vector2.zero;

	public int cursorSizeX  = 50;  // Your cursor size x
	public int cursorSizeY = 50;  // Your cursor size y

	//public GUIText cursorText;

	public void Start()
	{
		Screen.showCursor = false;
		//cursorText.text = "";
	}

	void Update () {
		//cursorText.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
	}

	/*void OnMouseEnter (Collider other) {
		print ("TALK TO GUY");
		if (other.name == "Spot_1") {

			cursorText.text = "TALK TO GUY..."; 
			print ("TALK TO GUY");
		}
		}

	void OnMouseExit (Collider other) {
		cursorText.text = "";
	}*/


	public void OnGUI()
	{
		Screen.showCursor = false;
		GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), cursorTexture);
	}
}