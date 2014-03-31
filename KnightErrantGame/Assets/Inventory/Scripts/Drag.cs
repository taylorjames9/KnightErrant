using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour
{
	Vector3 screenSpace;
	Vector3 offset;

	void OnMouseDrag ()
	{
		Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);     
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
		transform.position = curPosition;

	}

	void OnMouseDown ()
	{
		screenSpace = Camera.main.WorldToScreenPoint (transform.position) * 0.12f;
		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	}
	
}