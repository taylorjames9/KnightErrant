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

		//myHoverOverTXT.text = "Look Inside";


	}
	public void OnMouseExit () {
		myHoverOverTXT.renderer.enabled = false;
	}
}
