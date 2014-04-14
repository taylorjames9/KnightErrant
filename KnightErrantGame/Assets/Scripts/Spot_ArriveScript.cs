using UnityEngine;
using System.Collections;

public class Spot_ArriveScript : MonoBehaviour {

	public Transform myLandingSpot;
	public Transform knight;


		public static bool justArrivedAtLib;
		public static bool justArrivedAtPond;
		public static bool justArrivedAtPrep;
		public static bool justArrivedAtLiquor;
		public static bool justArrivedSchool;

		public static bool occupied;

	void OnMouseDown (){

				if(!occupied)
				GameManager.myDestination = myLandingSpot.transform;
		}

		void Update(){

				float dist = Vector3.Distance(knight.position, myLandingSpot.position);
				//print ("Dist =" + dist);

				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot0") {
						print ("I have arrived at trash");
						GameManager.currentGameState = GameManager.GameLocationState.Trash; 
						justArrivedSchool = false;
						justArrivedAtPond = false;
						justArrivedAtLib = false;
						justArrivedAtPrep = false;
						justArrivedAtLiquor = false;

				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot1" && justArrivedAtLiquor == false) {
						print ("I have arrived at addict");
						GameManager.currentGameState  = GameManager.GameLocationState.Addict; 
						GameManager.currentLiquorState = GameManager.LiquorState.Arrived;
						justArrivedSchool = false;
						justArrivedAtLiquor = true;
						justArrivedAtPond = false;
						justArrivedAtLib = false;
						justArrivedAtPrep = false;

				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot2" && justArrivedAtPrep == false) {
						print ("I have arrived at: Prep");
						GameManager.currentGameState  = GameManager.GameLocationState.Prep; 
						PrepScript.hitThePrep = 0;
						GameManager.currentPrepState = GameManager.PrepState.Arrived;
						justArrivedSchool = false;
						justArrivedAtPrep = true;
						justArrivedAtLib = false;
						justArrivedAtPond = false;
						justArrivedAtLiquor = false;

				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot3" && justArrivedAtPond == false && PondScript.hitThePond == 0) {
						print ("I have arrived at: pond");
						GameManager.currentGameState = GameManager.GameLocationState.Pond; 
						GameManager.currentPondState = GameManager.PondState.Arrived;
						justArrivedSchool = false;
						justArrivedAtPond = true;
						justArrivedAtLib = false;
						justArrivedAtPrep = false;
						justArrivedAtLiquor = false;
				} else {
						//justArrivedAtPond = false;
				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot4" && justArrivedSchool == false) {
						print ("I have arrived at: school");
						GameManager.currentGameState  = GameManager.GameLocationState.School; 
						GameManager.currentSchoolState = GameManager.SchoolState.Arrived;
						justArrivedSchool = true;
						justArrivedAtPond = false;
						justArrivedAtLib = false;
						justArrivedAtPrep = false;
						justArrivedAtLiquor = false;

				}
				if (myLandingSpot.gameObject.name == "LandingSpot5" && dist < 0.1 && justArrivedAtLib == false && LibraryScript.hitTheLibrary == 0) {
						print ("I have arrived at: Library");
						GameManager.currentGameState = GameManager.GameLocationState.Library; 
						GameManager.currentStudyState = GameManager.StudyState.Arrived;
						justArrivedSchool = false;
						justArrivedAtLib = true;
						justArrivedAtPond = false;
						justArrivedAtPrep = false;
						justArrivedAtLiquor = false;
				} else {
						//justArrivedAtLib = false;
				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot6") {
						print ("I have arrived at: Grail");
						GameManager.currentGameState  = GameManager.GameLocationState.Swirl; 
						justArrivedSchool = false;
						justArrivedAtPond = false;
						justArrivedAtLib = false;
						justArrivedAtPrep = false;
						justArrivedAtLiquor = false;
						//KnightController.isMoving = false;
				}
		}
}
