using UnityEngine;
using System.Collections;

public class HoverOverMe : MonoBehaviour {

	public TextMesh myHoverOverTXT;

	void Start(){
		myHoverOverTXT.renderer.enabled = false;

	}


	public void OnMouseEnter () {
		print ("Entered mouseOver of " + gameObject.name);
		myHoverOverTXT.renderer.enabled = true;
		//guiText.enabled = true;
		//myHoverOverTXT.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, myHoverOverTXT.transform.position.z);

		///////myHoverOverTXT.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);

	}
	public void OnMouseExit () {
		myHoverOverTXT.renderer.enabled = false;
	}
}
