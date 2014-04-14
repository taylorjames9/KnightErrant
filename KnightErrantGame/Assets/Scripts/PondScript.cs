using UnityEngine;
using System.Collections;

public class PondScript : MonoBehaviour {


		public static int hitThePond;

		// Use this for initialization
		void Start () {
				hitThePond = 0;
		}

		void OnMouseUp(){
				if (GameManager.currentPondState == GameManager.PondState.Arrived || GameManager.currentPondState == GameManager.PondState.Laying) {

						hitThePond++; 
						print ("hitThePond now equals " + hitThePond);
				}
		}
}
