﻿using UnityEngine;
using System.Collections;

public class ScrollCloseBTN : MonoBehaviour {


	public GameObject scrollOBJ;





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*print ("clicked on the close btn");

			switch (GameManager.currentGameState) {

			case GameManager.GameLocationState.Beginning:
				//showedBeginningText = true;
				scrollOBJ.SetActive (false);
				break;
			case GameManager.GameLocationState.Trash:
				if (GameManager.showedTrashText) {
					scrollOBJ.SetActive (false);
				}
				break;
			case GameManager.GameLocationState.Addict:
				//showedLiquorText = true;
				scrollOBJ.SetActive (false);
				break;
			case GameManager.GameLocationState.Prep:
				//showedPrepText = true;
				scrollOBJ.SetActive (false);
				break;
			case GameManager.GameLocationState.Pond:
				//showedPondText = true;
				scrollOBJ.SetActive (false);
				break;
			case GameManager.GameLocationState.Library:
				//showedStudyText = true;
				scrollOBJ.SetActive (false);
				break;
			}
		}*/
}

	public void OnMouseDown(){
		print ("MOUSE CLICK ON CLOSE BTN");
		switch (GameManager.currentGameState) {
		case GameManager.GameLocationState.Beginning:
			//showedBeginningText = true;
			scrollOBJ.SetActive (false);
			break;
		case GameManager.GameLocationState.Trash:
			if (GameManager.showedTrashText) {
				scrollOBJ.SetActive (false);
			}
			break;
		case GameManager.GameLocationState.Addict:
			//showedLiquorText = true;
			scrollOBJ.SetActive (false);
			break;
		case GameManager.GameLocationState.Prep:
			//showedPrepText = true;
			scrollOBJ.SetActive (false);
			break;
		case GameManager.GameLocationState.Pond:
			//showedPondText = true;
			scrollOBJ.SetActive (false);
			break;
		case GameManager.GameLocationState.Library:
			//showedStudyText = true;
			scrollOBJ.SetActive (false);
			break;

		default:
			break;
		}


		}

}
