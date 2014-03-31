using UnityEngine;
using System.Collections;

public class ItemManagerExample : ItemManager
{
	[SerializeField]
	CharScreen charScreen;
	CharScreen cs;
	
	  //example
	//***************
	public Item helmet;
	public Item staff;
	public Item manaPot;
	public Item shield;
	public Item healthPot;
	public Item hands;
	public Item pants;
	public Item sword;
	public Item ring;
	public Item shoulders;
	public Item chest;
	public Item bags;
	public Item feet;
	public Item chain;
	public Item tail;
	//***************
	
	
	void Start ()
	{		
	// examples
		Initialize ();
		SpawnCharacterScreen (new Vector3 (0.7f, -0.6f, layer));
		// to create a bag, choose how many colums and rows you want. -> position of the background -> offsets in %
		CreateBag (5, 1, new Vector3 (-0.45f, -0.6f, layer), 0.828f, -0.12f);
		//CreateBag (5, 1, new Vector3 (-0.45f, 0.4f, layer), 0.828f, -0.12f);
		//CreateBag (5, 1, new Vector3 (0.7f, 0.4f, layer), 0.828f, -0.12f);
		
	}
	
	// Example buttons to add items, bags etc.
	void OnGUI ()
	{
		
		if (GUI.Button (new Rect (0, 60, 100, 30), "add helmet")) {
			AddItem (helmet);
		}
		if (GUI.Button (new Rect (0, 90, 100, 30), "add staff")) {
			AddItem (staff);
		}
		if (GUI.Button (new Rect (0, 30, 150, 30), "Remove Item")) {
			RemoveItem ();
		}
		if (GUI.Button (new Rect (0, 0, 200, 30), "Create a bag ")) {
			CreateBag (5, 7, new Vector3 (-0.5f, 0, layer), 0.828f, -0.12f);
		}
		if (GUI.Button (new Rect (0, 120, 100, 30), "add ManaPot")) {
			AddItem (manaPot);
		}
		
		if (GUI.Button (new Rect (0, 150, 100, 30), "add HealthPot")) {
			AddItem (healthPot);
		}
		if (GUI.Button (new Rect (0, 180, 100, 30), "add chest")) {
			AddItem (chest);
		}
		if (GUI.Button (new Rect (0, 210, 100, 30), "add pants")) {
			AddItem (pants);
		}
		if (GUI.Button (new Rect (0, 240, 100, 30), "add hands")) {
			AddItem (hands);
		}
		
		if (GUI.Button (new Rect (0, 270, 100, 30), "add shield")) {
			AddItem (shield);
		}
		if (GUI.Button (new Rect (0, 300, 100, 30), "add bags")) {
			AddItem (bags);
		}
		if (GUI.Button (new Rect (0, 330, 100, 30), "add feet")) {
			AddItem (feet);
		}
		if (GUI.Button (new Rect (0, 360, 100, 30), "add sword")) {
			AddItem (sword);
		}
		if (GUI.Button (new Rect (0, 390, 100, 30), "add chain")) {
			AddItem (chain);
		}
		if (GUI.Button (new Rect (0, 420, 100, 30), "add shoulders")) {
			AddItem (shoulders);
		}
		if (GUI.Button (new Rect (0, 450, 100, 30), "add ring")) {
			AddItem (ring);
		}
		if (GUI.Button (new Rect (0, 480, 100, 30), "add tail")) {
			AddItem (tail);
		}
	}
	
	// To spawn the charscreen.
	void SpawnCharacterScreen (Vector3 pos)
	{
		cs = Instantiate (charScreen) as CharScreen;
		cs.transform.localScale = backGroundScale;
		cs.transform.position = pos;
		++layer;
		cs.SetManagerForCharScreen (this);
	}
	
	
	// Here a short charscreen example -> ItemNode calls this function on rightclick.
	// It looks if the item that was rightclicked is a weapon / armor. Than it compares , for example if the items is a sword or shield
	public override void OnUse (ItemNode node)
	{
		if (node.GetItem () is Equip) {
			foreach (ItemNode charScreenNode in cs.itemNodes) {
				if (node.GetItem () is Armor) {
				
					if (charScreenNode is ItemNodeArmor && (charScreenNode as ItemNodeArmor).onlyAcceptThisType == (node.GetItem () as Armor).armorType) {
						if (charScreenNode.GetItem ()) {
							Swap (node.GetItem (), charScreenNode, node);
						} else {
							charScreenNode.SetItem (node.GetItem ());
							node.RemoveItem ();
							RecalculateInventoryCount ();
							return;
						}
					}
				} else if (node.GetItem () is Weapon) {
					if (charScreenNode is ItemNodeWeapon && (charScreenNode as ItemNodeWeapon).onlyAcceptThisType == (node.GetItem () as Weapon).weaponType) {
						if (charScreenNode.GetItem ()) {
							Swap (node.GetItem (), charScreenNode, node);
						} else {
							charScreenNode.SetItem (node.GetItem ());
							node.RemoveItem ();
							RecalculateInventoryCount ();
							return;
						}
					}
				}
			}
		}
	}
}
