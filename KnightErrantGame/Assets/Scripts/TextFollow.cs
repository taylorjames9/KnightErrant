using UnityEngine;
using System.Collections;

public class TextFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);

	}
}

