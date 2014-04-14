using UnityEngine;
using System.Collections;

public class PrepScript : MonoBehaviour {

		public static int hitThePrep;

		// Use this for initialization
		void Start () {
				hitThePrep = 0;
		}

		void OnMouseUp(){
				print ("GameManager.currentPrepState =" + GameManager.currentPrepState);
				if (GameManager.currentPrepState == GameManager.PrepState.Arrived || GameManager.currentPrepState == GameManager.PrepState.Test) {

						hitThePrep++; 
						print ("hitThePrep now equals " + hitThePrep);
				}
		}
}
