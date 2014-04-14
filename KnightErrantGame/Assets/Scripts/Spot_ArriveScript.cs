using UnityEngine;
using System.Collections;

public class Spot_ArriveScript : MonoBehaviour {

	public Transform myLandingSpot;
	public Transform knight;


		public static bool justArrivedAtLib;
		public static bool justArrivedAtPond;

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
						//KnightController.isMoving = false;

				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot1") {
						print ("I have arrived at addict");
						GameManager.currentGameState  = GameManager.GameLocationState.Addict; 
						//KnightController.isMoving = false;

				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot2") {
						print ("I have arrived at: Prep");
						GameManager.currentGameState  = GameManager.GameLocationState.Prep; 
						GameManager.currentPrepState = GameManager.PrepState.Arrived;

						//KnightController.isMoving = false;

				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot3" && justArrivedAtPond == false && PondScript.hitThePond == 0) {
						print ("I have arrived at: pond");
						GameManager.currentGameState = GameManager.GameLocationState.Pond; 
						GameManager.currentPondState = GameManager.PondState.Arrived;
						justArrivedAtPond = true;
						justArrivedAtLib = false;
				} else {
						//justArrivedAtPond = false;
				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot4") {
						print ("I have arrived at: school");
						GameManager.currentGameState  = GameManager.GameLocationState.School; 
						//KnightController.isMoving = false;

				}
				if (myLandingSpot.gameObject.name == "LandingSpot5" && dist < 0.1 && justArrivedAtLib == false && LibraryScript.hitTheLibrary == 0) {
						print ("I have arrived at: Library");
						GameManager.currentGameState = GameManager.GameLocationState.Library; 
						GameManager.currentStudyState = GameManager.StudyState.Arrived;
						justArrivedAtLib = true;
						justArrivedAtPond = false;
				} else {
						//justArrivedAtLib = false;
				}
				if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot6") {
						print ("I have arrived at: Grail");
						GameManager.currentGameState  = GameManager.GameLocationState.Swirl; 
						//KnightController.isMoving = false;
				}
		}
}
