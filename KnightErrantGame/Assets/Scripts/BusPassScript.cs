using UnityEngine;
using System.Collections;

public class BusPassScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnMouseDown(){
				if (GameManager.currentLiquorState == GameManager.LiquorState.GiveHimSomething && !CameraCursorScript.tappedBusPass) {
						print ("WE HIT THE BUS PASS");
						CameraCursorScript.tappedBusPass = true;
				}

		}
}
