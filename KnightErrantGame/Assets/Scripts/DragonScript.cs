using UnityEngine;
using System.Collections;

public class DragonScript : MonoBehaviour {


		public static bool engageDragon;
		public static int dragonBlows;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void OnMouseUp(){
				//print ("GameManager.currentPrepState =" + GameManager.currentPrepState);
				if (GameManager.currentSchoolState == GameManager.SchoolState.Arrived) {
						engageDragon = true;
						print ("FIGHT THE DRAGON");
						GameManager.currentSchoolState = GameManager.SchoolState.Battle;
				}

				if (GameManager.currentSchoolState == GameManager.SchoolState.Battle) {
						//KnightController.currentAnimState = KnightController.CurrentAnimationState.PokeDragon;
						dragonBlows++;
						GameManager.poking = false;
						print ("DragonBlows =" + dragonBlows);
				}
		}
}
