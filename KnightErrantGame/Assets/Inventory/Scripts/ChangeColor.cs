using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GetComponent<GUIText> ().material.color = Color.black;
	}
	
	
}
