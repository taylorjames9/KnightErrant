using UnityEngine;
using System.Collections;

public class HoverOverMe : MonoBehaviour {

	public TextMesh myHoverOverTXT;

	void Start(){
		myHoverOverTXT.renderer.enabled = false;

	}


	public void OnMouseEnter () {
		myHoverOverTXT.renderer.enabled = true;

	}
	public void OnMouseExit () {
		myHoverOverTXT.renderer.enabled = false;
	}
}
