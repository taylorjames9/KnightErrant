using UnityEngine;
using System.Collections;

public class Spot1_Script : MonoBehaviour {

	public Transform myLandingSpot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown (){

				GameManager.myDestination = myLandingSpot.transform;
				print ("This is from spot1: "+GameManager.myDestination);

	}
}
