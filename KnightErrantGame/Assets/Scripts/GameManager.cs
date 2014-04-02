using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


		public GameObject knight;
		public static Transform myDestination; 




		public enum GameLocationState{Addict, Prep, Pond, Library, School, Trash, Grail, Between};
		public static GameLocationState currentGameState;
	

	// Use this for initialization
	void Start () {

				currentGameState = GameLocationState.Between; 
	}
	
	// Update is called once per frame
	void Update () {


				switch (currentGameState) {
				case GameLocationState.Addict:
						print ("We are now in the addict chapter");
						break;
				case GameLocationState.Prep:
						print ("We are now in the prep chapter");

						break;
				case GameLocationState.Pond:
						print ("We are now in the pond chapter");

						break;
				case GameLocationState.Library:
						print ("We are now in the library chapter");

						break;
				case GameLocationState.School:
						print ("We are now in the school chapter");

						break;
				case GameLocationState.Trash:
						print ("We are now in the Trash chapter");

						break;
				case GameLocationState.Grail:
						print ("We are now in the Grail chapter");

						if (InventoryOnKnight.inventoryInPossessionList.Count >= 6) {
								StartCoroutine (PlayBadEnding ("GoodEnding"));
						} else {
								StartCoroutine (PlayBadEnding ("BadEnding"));
						}


						break;
				case GameLocationState.Between:
						print ("I am between states");
						break;
				default:

						break;
				}
	}


		IEnumerator PlayBadEnding(string endingType){
				yield return new WaitForSeconds (1.0f);
				Application.LoadLevel (endingType);

		}

}
