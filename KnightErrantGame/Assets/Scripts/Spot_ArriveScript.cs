﻿using UnityEngine;
using System.Collections;

public class Spot_ArriveScript : MonoBehaviour {

	public Transform myLandingSpot;
	public Transform knight;


	void OnMouseDown (){

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
				else if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot1") {
						print ("I have arrived at addict");
						GameManager.currentGameState  = GameManager.GameLocationState.Addict; 
						//KnightController.isMoving = false;

				}
				else if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot2") {
						print ("I have arrived at: Prep");
						GameManager.currentGameState  = GameManager.GameLocationState.Prep; 
						//KnightController.isMoving = false;

				}
				else if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot3") {
						print ("I have arrived at: pond");
						GameManager.currentGameState  = GameManager.GameLocationState.Pond; 
						//KnightController.isMoving = false;

				}
				else if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot4") {
						print ("I have arrived at: school");
						GameManager.currentGameState  = GameManager.GameLocationState.School; 
						//KnightController.isMoving = false;

				}
				else if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot5") {
						print ("I have arrived at: Library");
						GameManager.currentGameState  = GameManager.GameLocationState.Library; 
						//KnightController.isMoving = false;

				}
				else if (dist < 0.1 && myLandingSpot.gameObject.name == "LandingSpot6") {
						print ("I have arrived at: Grail");
						GameManager.currentGameState  = GameManager.GameLocationState.Swirl; 
						//KnightController.isMoving = false;
				}
		}
}
