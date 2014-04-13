using UnityEngine;
using System.Collections;

public class ScrollCloseBTN : MonoBehaviour {


	public GameObject scrollOBJ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
			if (GameManager.showedPondText) {
				print ("SHOULD BE CLOSING THE SCROLL");
								//scrollOBJ.renderer.enabled = false;
								scrollOBJ.SetActive (false);
					}
			break;
		case GameManager.GameLocationState.Library:
			//showedStudyText = true;
			if (GameManager.showedStudyText) {
					scrollOBJ.SetActive (false);
			}
			break;

		default:
			break;
		}


		}

}
