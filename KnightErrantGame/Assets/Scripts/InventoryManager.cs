using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {


		public static Transform Spot_1_Transform;
		public static Transform Spot_2_Transform;
		public static Transform Spot_3_Transform;
		public static Transform Spot_4_Transform;
		public static Transform Spot_5_Transform;
		public static Transform Spot_6_Transform;


		public GameObject BusPass;
		public GameObject Failure;
		public GameObject Frustration;
		public GameObject Pers;
		public GameObject Boredom;
		public GameObject work;

		public static bool gotBusPass;
		static bool gotPerspective;
		static bool gotFailure;
		static bool gotWork;
		static bool gotBoredom;
		static bool gotFrustration;

		// Use this for initialization
		void Start () {

		//InventoryOnKnight.inventoryInPossessionList.Add (BusPass);

				BusPass.SetActive(false);
				Failure.SetActive(false);
				Frustration.SetActive(false);
				Pers.SetActive(false);
				Boredom.SetActive(false);
				work.SetActive (false);

		}
	
	// Update is called once per frame
	void Update () {

				switch (GameManager.currentGameState) {
				
				case GameManager.GameLocationState.Trash:
					print ("We are now in the Trash chapter");
					
				if (!gotBusPass && GameManager.lookInTrash) {
						BusPass.SetActive (true);
						InventoryOnKnight.inventoryInPossessionList.Add (BusPass);
						gotBusPass = true;
					}
						break;
				case GameManager.GameLocationState.Addict:
						print ("We are now in the addict chapter");
						Pers.SetActive (true);
					if (!gotPerspective) {
								InventoryOnKnight.inventoryInPossessionList.Add (Pers);
								gotPerspective = true;
						}
						break;
				case GameManager.GameLocationState.Prep:
						print ("We are now in the prep chapter");
						Failure.SetActive (true);
						if (!gotFailure) {
								InventoryOnKnight.inventoryInPossessionList.Add (Failure);
								gotFailure = true;
						}
						break;
				case GameManager.GameLocationState.Pond:
						print ("We are now in the pond chapter");
						Boredom.SetActive (true);
						if (!gotBoredom) {
								InventoryOnKnight.inventoryInPossessionList.Add (Boredom);
								gotBoredom = true;
						}
						break;
				case GameManager.GameLocationState.Library:
						print ("We are now in the library chapter");
						work.SetActive (true);
						if (!gotWork) {
								InventoryOnKnight.inventoryInPossessionList.Add (work);
								gotWork = true;
						}
						break;
				case GameManager.GameLocationState.School:
						print ("We are now in the school chapter");
						Frustration.SetActive (true);
						if (!gotFrustration) {
								InventoryOnKnight.inventoryInPossessionList.Add (Frustration);
								gotFrustration = true;
						}
						break;
				default:

						break;
				}
				print ("InventorySpot count " + InventoryOnKnight.inventoryInPossessionList.Count);
	}
}
