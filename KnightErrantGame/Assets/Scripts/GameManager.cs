using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


		public GameObject knight;
		public static Transform myDestination; 
		public AudioClip knightWalk;
		public GameObject scrollParchment;
		public TextMesh scrollTXT;
		public GameObject iconOnScroll;
		public  Texture[] textures;

	public static bool showedBeginningText;
	public static  bool showedTrashText;
	public static  bool showedPrepText;
	public static  bool showedLiquorText;
	public static  bool showedPondText;
	public static  bool showedSchoolText;
	public static  bool showedStudyText;


		public enum GameLocationState{Addict, Prep, Pond, Library, School, Trash, Swirl, Beginning, Between};
		public static GameLocationState currentGameState;

		public enum PondState {Arrived, Laying, StandAfterLaying, OpenScroll, Void};
		public static PondState currentPondState;



		public TextMesh atTrashText;
		public TextMesh atPondText;
		

		public static bool lookInTrash; 
		public static bool layInPond; 

	

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
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
					
						break;

				case GameLocationState.Addict:
						print ("We are now in the addict chapter");
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
						break;
				case GameLocationState.Prep:
						print ("We are now in the prep chapter");
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;

						break;
				case GameLocationState.Pond:
						print ("We are now in the pond chapter");
						//KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
						switch (currentPondState) {
						case PondState.Arrived:
								atPondText.text = "Lay Down \n By Pond?";
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								if (Input.GetMouseButton (0)) {
										KnightController.currentAnimState = KnightController.CurrentAnimationState.LayingDown;
										currentPondState = PondState.Laying;
								}
								break;
						case PondState.Laying:
								StartCoroutine (IsLayingThere());
								break;
						case PondState.StandAfterLaying:
								KnightController.currentAnimState = KnightController.CurrentAnimationState.StandingUp;
								//GameLocationState
								currentPondState = PondState.OpenScroll;
								break;
						case PondState.OpenScroll:
								showedPondText = true;
								scrollParchment.SetActive (true);
								scrollTXT.text = "You received the breast plate \nof profound boredom.";
								iconOnScroll.renderer.material.mainTexture = textures [4];

								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								print ("currentGameState = " + currentGameState);
								currentGameState = GameLocationState.Between;
								currentPondState = PondState.Void;
								break;
						default:
								break;
						}
						break;

				case GameLocationState.Library:
								print ("We are now in the library chapter");
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;


					break;
				case GameLocationState.School:
								print ("We are now in the school chapter");
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;


					break;
				case GameLocationState.Trash:
								print ("We are now in the Trash chapter");
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;

								atTrashText.text = "Look Inside?";
								if (Input.GetMouseButton (0)) {
										lookInTrash = true;
								}
								if (InventoryManager.gotBusPass && !showedTrashText) {
										scrollParchment.SetActive (true);
										scrollTXT.text = "You found a bus pass \n in the garbage.";
								iconOnScroll.renderer.material.mainTexture = textures[0];
										showedTrashText = true;
								}
					break;
				case GameLocationState.Swirl:
								print ("We are now in the Grail chapter");
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;


								if (InventoryOnKnight.inventoryInPossessionList.Count >= 6) {
										StartCoroutine (PlayBadEnding ("GoodEnding"));
								} else {
										StartCoroutine (PlayBadEnding ("BadEnding"));
								}
								break;

						case GameLocationState.Between:
								print ("We are now in the Between");
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								break;

						default:
								break;
						}

				/*if (!KnightController.isMoving) {
					audio.Play ();
						}*/
						
		}
		IEnumerator PlayBadEnding(string endingType){
				yield return new WaitForSeconds (1.0f);
				Application.LoadLevel (endingType);

		}

		IEnumerator IsLayingThere(){
				yield return new WaitForSeconds (2.0f);
				KnightController.currentAnimState = KnightController.CurrentAnimationState.LayingThere;
				atPondText.text = "Up and at 'em?";
				if (Input.GetMouseButton (0)) {
						currentPondState = PondState.StandAfterLaying;
				}
				yield return new WaitForSeconds (0);
		}
}
