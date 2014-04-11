using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


		public GameObject knight;
		public static Transform myDestination; 
		public AudioClip knightWalk;
		public GameObject scrollParchment;
		public TextMesh scrollTXT;

	public static bool showedBeginningText;
	public static  bool showedTrashText;
	public static  bool showedPrepText;
	public static  bool showedLiquorText;
	public static  bool showedPondText;
	public static  bool showedSchoolText;
	public static  bool showedStudyText;


	public enum GameLocationState{Addict, Prep, Pond, Library, School, Trash, Grail, Beginning};
		public static GameLocationState currentGameState;


		public TextMesh atTrashText;
		

		public static bool lookInTrash; 

	

	// Use this for initialization
	void Start () {

		currentGameState = GameLocationState.Beginning; 
				scrollParchment.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


				switch (currentGameState) {
				case GameLocationState.Beginning:
					print ("In the beginning");
					
					break;

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
						atTrashText.text = "Look Inside?";
					if (Input.GetMouseButton (0)) {
						lookInTrash = true;
					}
					if (InventoryManager.gotBusPass && !showedTrashText) {
						scrollParchment.SetActive (true);
						scrollTXT.text = "You found a bus pass \n in the garbage.";
						showedTrashText = true;
					}
					

					break;
				case GameLocationState.Grail:
						print ("We are now in the Grail chapter");

						if (InventoryOnKnight.inventoryInPossessionList.Count >= 6) {
								StartCoroutine (PlayBadEnding ("GoodEnding"));
						} else {
								StartCoroutine (PlayBadEnding ("BadEnding"));
						}


						break;
				default:
						break;
				}

				if (!KnightController.isMoving) {
				//audio.PlayOneShot (knightWalk, 1.0f);

						audio.Play ();
				} else {
						//audio.Stop ();
				}


	}
		IEnumerator PlayBadEnding(string endingType){
				yield return new WaitForSeconds (1.0f);
				Application.LoadLevel (endingType);

		}

}
