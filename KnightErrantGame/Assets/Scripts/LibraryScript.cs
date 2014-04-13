using UnityEngine;
using System.Collections;

public class LibraryScript : MonoBehaviour {


		public static int hitTheLibrary;

	// Use this for initialization
	void Start () {
				hitTheLibrary = 0;
	}
	
	// Update is called once per frame
	void Update () {


	
	}

		void OnMouseUp(){
				if (GameManager.currentStudyState == GameManager.StudyState.Arrived || GameManager.currentStudyState == GameManager.StudyState.StaySeated) {

						hitTheLibrary++; 
						print ("Hit the library now equals " + hitTheLibrary);

				}

		}

}
