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
		public AnimationClip PoofAnim;
		public GameObject SATQ;

		public static bool showedBeginningText;
		public static  bool showedTrashText;
		public static  bool showedPrepText;
		public static  bool showedLiquorText;
		public static  bool showedPondText;
		public static  bool showedSchoolText;
		public static  bool showedStudyText;
		public static  bool showedSATQ;


		public static bool poofAudio;
		public AudioClip poofAudioClip;

		public enum GameLocationState{Addict, Prep, Pond, Library, School, Trash, Swirl, Beginning, Between};
		public static GameLocationState currentGameState;

		public enum PondState {Arrived, Laying, StandAfterLaying, OpenScroll, Void};
		public static PondState currentPondState;

		public enum StudyState {WalkingThereToLib, Arrived, SittingAction, StaySeated, Stand, OpenScroll, Void};
		public static StudyState currentStudyState;

		public enum PrepState {Arrived, PromptToTakeTest, Test, OpenScroll, Void};
		public static PrepState currentPrepState;

		public TextMesh atTrashText;
		public TextMesh atPondText;
		public TextMesh atLibraryText;
		public TextMesh atPrepText;
		

		public static bool lookInTrash; 
		public static bool layInPond; 

		public GameObject swirlObject;

	

	// Use this for initialization
	void Start () {

		currentGameState = GameLocationState.Beginning; 
				scrollParchment.SetActive (false);
				showedBeginningText = false;
				currentStudyState = StudyState.Void;
				currentPondState = PondState.Void;
				SATQ.SetActive (false);

				showedBeginningText = false;
				showedTrashText = false;
				showedPrepText = false;
				showedLiquorText = false;
				showedPondText = false;
				showedSchoolText = false;
				showedStudyText = false;
				showedSATQ = false;
	}
	
	// Update is called once per frame
	void Update () {

				switch (currentGameState) {
				case GameLocationState.Beginning:
						print ("In the beginning");

						StartCoroutine (StartBeginning ());

						StartCoroutine (ShowBegParchment ());
						showedBeginningText = true; 
					
						break;

				case GameLocationState.Addict:
						print ("We are now in the addict chapter");
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
						break;


				case GameLocationState.Prep:
						switch (currentPrepState) {
						case PrepState.Arrived:
								atPrepText.text = "Try thy hand at the\nformiddable test?";
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								print ("hitThePrepBuildingCount = " + PrepScript.hitThePrep);
								if (PrepScript.hitThePrep%2 ==1) {
										SATQ.SetActive (true);
										showedSATQ = true;
										PrepScript.hitThePrep++;
										Spot_ArriveScript.occupied = true;
										//currentPrepState = PrepState.Test;
								}
								break;
						case PrepState.Test:
								break;
						case PrepState.OpenScroll:
								StartCoroutine (OpenPrepScroll ());
								Spot_ArriveScript.occupied = true;

								break;
						case PrepState.Void:
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								Spot_ArriveScript.occupied = false;
								break;

						default:
								break;

						}
						break;
				
				case GameLocationState.Pond:
						print ("We are now in the pond chapter");
						//KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
						switch (currentPondState) {
						case PondState.Arrived:
								atPondText.text = "Lay Down \n by Pond?";
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								if (PondScript.hitThePond ==1) {
										KnightController.currentAnimState = KnightController.CurrentAnimationState.LayingDown;
										currentPondState = PondState.Laying;
								}
								Spot_ArriveScript.occupied = false;
								break;
						case PondState.Laying:
								Spot_ArriveScript.occupied = true;
								StartCoroutine (IsLayingThere());
								break;
						case PondState.StandAfterLaying:
								KnightController.currentAnimState = KnightController.CurrentAnimationState.StandingUp;
								PondScript.hitThePond = 0;
								//GameLocationState
								currentPondState = PondState.OpenScroll;
								break;
						case PondState.OpenScroll:

								if (!showedPondText) {
										Spot_ArriveScript.occupied = true;
										scrollParchment.SetActive (true);
										scrollTXT.text = "You received the breast plate \nof profound boredom.";
										iconOnScroll.renderer.material.mainTexture = textures [4];
										showedPondText = true;
								}

								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								print ("currentGameState = " + currentGameState);
								//currentGameState = GameLocationState.Between;
								currentPondState = PondState.Void;
								break;
						case PondState.Void:
								atPondText.text = "Lay Down \n by Pond?";
								Spot_ArriveScript.occupied = false;
								break;
						default:
								break;
						}
						break;

				case GameLocationState.Library:
						print ("We are now in the library chapter");

						switch (currentStudyState) {
						case StudyState.WalkingThereToLib:
								break;
						case StudyState.Arrived:
								Spot_ArriveScript.occupied = false;
								print ("LibraryState is ARRIVED");
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								atLibraryText.text = "Sit to read?";
								if (LibraryScript.hitTheLibrary == 1) {
										print ("LibraryState is ARRIVED and nOW SITTING");
										//LibraryScript.hitTheLibrary = 0;
										KnightController.currentAnimState = KnightController.CurrentAnimationState.SittingToRead;
										currentStudyState = StudyState.StaySeated;
								} else {
										KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;

								}
								break;
						case StudyState.StaySeated:
								Spot_ArriveScript.occupied = true;
								print ("LibraryState is STAYSEATED");
								atLibraryText.text = "Up and at 'em?";
								KnightController.currentAnimState = KnightController.CurrentAnimationState.StaySeated;
								if (LibraryScript.hitTheLibrary == 2) {
										KnightController.currentAnimState = KnightController.CurrentAnimationState.StandFromReading;
										LibraryScript.hitTheLibrary = 0;
										currentStudyState = StudyState.Stand;

								}
								break;
						case StudyState.Stand:
								print ("LibraryState is STAND");
								atLibraryText.text = "Sit to read?";
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								currentStudyState = StudyState.OpenScroll;
								break;
						case StudyState.OpenScroll:
								if(!showedStudyText){
								Spot_ArriveScript.occupied = true;
								print ("LibraryState is OPENSCROLL");
								KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
								scrollParchment.SetActive (true);
								scrollTXT.text = "You received the chalice of \nknowledge. Or something like that.";
								showedStudyText = true;
						}
								iconOnScroll.renderer.material.mainTexture = textures [3];
								currentStudyState = StudyState.Void;
								//Spot_ArriveScript.justArrivedAtLib = false;
								break;
						case StudyState.Void:
								atLibraryText.text = "Sit to read";
								Spot_ArriveScript.occupied = false;
								break;
						default:
								break;

						}

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
				if (PondScript.hitThePond ==2) {
						currentPondState = PondState.StandAfterLaying;
				}
				yield return new WaitForSeconds (0);
		}
		IEnumerator StartBeginning(){

				if (!showedBeginningText) {
						knight.renderer.enabled = false;
						yield return new WaitForSeconds (2.0f);
						KnightController.currentAnimState = KnightController.CurrentAnimationState.Poof;
						poofAudio = true;
						yield return new WaitForSeconds (0.1f);
						knight.renderer.enabled = true;
						KnightController.currentAnimState = KnightController.CurrentAnimationState.IdleWait;
						Spot_ArriveScript.occupied = true;
						yield return new WaitForSeconds (0.0f);
				}
		}
		IEnumerator ShowBegParchment(){
				if (!showedBeginningText) {
						yield return new WaitForSeconds (4.0f);
						//audio.PlayOneShot (poofAudioClip, 0.9f);
						//swirlObject.audio.Play ();
						poofAudio = true;
						scrollParchment.SetActive (true);
						scrollTXT.text = "My lad, see if thou can not find some\nexperience in this modern era to make \nthee stand from thy peers in my court...";
						iconOnScroll.renderer.material.mainTexture = textures [6];
						StartCoroutine(EndSound ());
						showedBeginningText = true;
				}
				yield return new WaitForSeconds (0);
		}
		IEnumerator EndSound(){

				yield return new WaitForSeconds (1.0f);
				poofAudio = false;
				yield return new WaitForSeconds (0);
		}
		IEnumerator OpenPrepScroll(){
				yield return new WaitForSeconds (1.5f);
				if (!showedPrepText) {
						Spot_ArriveScript.occupied = true;
						scrollParchment.SetActive (true);
						scrollTXT.text = "You received the shin guards \nof unbelievable failure.";
						iconOnScroll.renderer.material.mainTexture = textures [2];
						showedPrepText = true;
				}
				yield return new WaitForSeconds (0);
		}



}
