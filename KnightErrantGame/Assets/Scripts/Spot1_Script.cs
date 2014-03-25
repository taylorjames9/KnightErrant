using UnityEngine;
using System.Collections;

public class Spot1_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown (){

				GameManager.myDestination = this.transform;
				print ("This is from spot1: "+GameManager.myDestination);

	}
}
