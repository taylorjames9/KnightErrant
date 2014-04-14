using UnityEngine;
using System.Collections;

public class SatQCloseBtn : MonoBehaviour {


		public GameObject SATQ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public void OnMouseDown(){
				print ("HITTING THE SAT CLOSE BTN");
				SATQ.SetActive (false);
				PrepScript.hitThePrep = 0;
				GameManager.currentPrepState = GameManager.PrepState.OpenScroll;
				//GameManager.currentPrepState = GameManager.PrepState.Test;
		}
}
