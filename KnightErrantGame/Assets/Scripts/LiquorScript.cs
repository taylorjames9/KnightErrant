using UnityEngine;
using System.Collections;

public class LiquorScript : MonoBehaviour {

		public static int hitTheGuy;
		public static bool gaveBusToGuy;

		// Use this for initialization
		void Start () {
				hitTheGuy = 0;
				gaveBusToGuy = false;

		}

		void OnMouseUp(){
				//print ("GameManager.currentPrepState =" + GameManager.currentPrepState);
				if (GameManager.currentLiquorState == GameManager.LiquorState.Arrived) {

						hitTheGuy++; 
						print ("hitThLiquoree now equals " + hitTheGuy);
				}
		}

		void OnMouseDown(){
				if (GameManager.currentLiquorState == GameManager.LiquorState.GiveHimSomething && CameraCursorScript.currentlyHaveBusFinger) {
						//hitTheGuy++;
						gaveBusToGuy = true;
						print ("OFFICIALLY GAVE THE BUS PASS TO THE GUY");
				}
		}
}
