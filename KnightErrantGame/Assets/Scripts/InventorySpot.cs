using UnityEngine;
using System.Collections;

public class InventorySpot : MonoBehaviour {


	GameObject itemInSpot;
	bool iAmEmpty; 


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		iAmEmpty = false; 
		itemInSpot = other.gameObject;
				//print ("itemInSpot " + itemInSpot.gameObject.name);
	}

}
