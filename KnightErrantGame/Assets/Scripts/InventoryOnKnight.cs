using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryOnKnight : MonoBehaviour {


	public static int numItemsinInventory;
	//This is how you create a list. Notice how the type
	//is specified in the angle brackets (< >).
	public static List<GameObject> inventoryInPossessionList = new List<GameObject>();


	static bool gotPerspective;
	static bool gotFailure;
	static bool gotWork;
	static bool gotBoredom;
	static bool gotFrustration;
	static bool gotLearning; 

	//Here you add 3 BadGuys to the List

		///////inventoryInPossessionList.Add();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
