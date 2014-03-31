using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
   
	
	[SerializeField]
	ItemNode itemNode;
	Vector3 scale;
	[SerializeField]
	float itemX = 40f;
	[SerializeField]
	float itemY = 40f;
	[SerializeField]
	float offset = 40f ;
	int inventoryCount;
	int maxInventorySlots;
	ItemNode lastItemNode;
	protected bool isDragging;
	protected Item draggedItem;
	protected ItemNode savedNode;
	List<ItemNode[,]> bag = new List<ItemNode[,]> ();
	[SerializeField]
	Drag Background;
	protected Vector3 backGroundScale;
	float backGroundX = 366;
	float backGroundY = 300;
	protected float layer = 0f;
	
	protected void Initialize ()
	{
		// To make UI resolution independed -> 2d cam scale has to be 1 !
		float downScaling = (((camera.orthographicSize * 2) / camera.pixelHeight));
		offset *= downScaling;
		scale = new Vector3 (itemX, 1, itemY) * downScaling * 0.1f;
		backGroundScale = new Vector3 (backGroundX, 1, backGroundY) * downScaling * 0.1f;	
		
	
	}
	
	
	// You can create bags at runtime. The size can be completley custom.
	public void CreateBag (int columns, int rows, Vector3 bagPosition, float offsetX, float offsetY)
	{
	
		Drag bag = Instantiate (Background) as Drag;
		bag.transform.localScale = backGroundScale;
		bag.transform.position = bagPosition;
		++layer;

		float planeTopLeftX = bag.transform.position.x + bag.collider.bounds.extents.x;
		float planeTopLeftY = bag.transform.position.y + bag.collider.bounds.extents.y;
		float planeWidth = bag.collider.bounds.size.x;

		float planeHeight = bag.collider.bounds.size.y;
		
		Vector3 position = new Vector3 (planeTopLeftX - (planeWidth * offsetX), planeTopLeftY + (planeHeight * offsetY), 1);
	
		ItemNode[,] itemNodes = new ItemNode[columns, rows];
		for (int i = 0; i<columns; i++) {
			if (i != 0)
				position.x -= offset * rows;
			position.y -= offset;
			for (int j = 0; j<rows; j++) {
				ItemNode node = Instantiate (itemNode) as ItemNode;
				if (node) {
					node.transform.localScale = scale;
					node.transform.localPosition = position;
					position.x += offset;
					node.transform.parent = bag.transform;
					Vector3 buffer = node.transform.localPosition;
					buffer.y = layer + 2;
					node.transform.localPosition = buffer;
					node.SetManager (this);
					itemNodes [i, j] = node;
				} else {
					Debug.LogError ("Could not spawn ItemNode - NullPointer");
				}
			}
		}
		maxInventorySlots += (columns * rows);
		this.bag.Add (itemNodes);
	}
	
	
	// call this function if you want to add an item
	public void AddItem (Item item)
	{
		if (item) {
			if (item is Equip) {
				AddEquip (item);
			} else if (item is UseableItem) {
				AddEquip (item);
// *** Stacking will be implemented soon ***
// *********************************
//				foreach (ItemNode[,] itemNodes in bag) {
//					foreach (ItemNode node in itemNodes) {
//						if (node.GetItem () && node.GetItem ().name.Equals (item.name)) {
//							(node.GetItem () as UseableItem).AddToStack ();
//							return;
				//					}
//					}
//		
//				}
				
			}
		}
	}
	
	// this function is called in "AddItem". It will just add an item to the inventory without stacking them. 
	void AddEquip (Item item)
	{
		if (inventoryCount < maxInventorySlots) {
			foreach (ItemNode[,] itemNodes in bag) {
			
				for (int i = 0; i<itemNodes.GetLength(0); i++) {
					for (int j = 0; j<itemNodes.GetLength(1); j++) {
						if (itemNodes [i, j].GetItem () == null) {
							itemNodes [i, j].SetItem (item);
							OnItemAdded ();
							return;
						}
					}
				}
			
			} 
		} else {
			OnInventoryFull ();
			
		}	
	}
	
	
	// This function will remove the LAST item in you inventory
	public void RemoveItem ()
	{
		if (inventoryCount > 0) {
			foreach (ItemNode[,] itemNodes in bag) {
				for (int i = 0; i<itemNodes.GetLength(0); i++) {
					for (int j = 0; j<itemNodes.GetLength(1); j++) {
						if (itemNodes [i, j].GetItem ()) {
							lastItemNode = itemNodes [i, j];
						} 
					}
				}
			}
			if (lastItemNode) {
				lastItemNode.RemoveItem ();
				OnItemRemoved ();
			}
			
		} else {
			OnInventoryEmpty ();	
		}	
	}
	
	
	// this function will be called if the inventory is empty and you want to remove an item
	// You can customize this function
	protected virtual void OnInventoryEmpty ()
	{
		Debug.Log ("Inventory is empty");
	}
	
	// this function is called if you remove an item
	protected virtual void OnItemRemoved ()
	{
		RecalculateInventoryCount ();
	}
	
	// this function is called if you add an item
	protected virtual void OnItemAdded ()
	{
		RecalculateInventoryCount ();
	}
	// this function will be called if the inventory is full  and you want to add an item
	protected void OnInventoryFull ()
	{
		Debug.Log ("Inventory is full");
	}

	//***************** DUMMY**********************
	// Just for demonstration purpose
	
	
	
	//  You can drag an item with this function, this function will be called from ItemNode
	public void OnDrag (ItemNode node)
	{
		if (!isDragging && node && node.GetItem ()) {
			isDragging = true;
			draggedItem = node.GetItem ();
			node.RemoveItem ();
			savedNode = node;
		}
	}
	
	// This functions gets called if the drag ends
	public void OnDragEnded ()
	{  
		isDragging = false;
		DropItem ();
	}
	
	protected void RecalculateInventoryCount ()
	{
		int count = 0;
		foreach (ItemNode[,] nodes in bag) {
			foreach (ItemNode node in nodes) {
				if (node.GetItem ()) {
					++count;
				}
			}
		} 
		Debug.Log ("Current Inventory count: "+count);
		inventoryCount = count;
	}
	// You want to drop an item, when its dragged
	void DropItem ()
	{
		if (draggedItem) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
	
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.tag.Equals ("ItemNode")) {
					ItemNode node = hit.transform.GetComponent<ItemNode> ();
					if (!node.GetItem ()) {
						if (node) {
							if (node.SetItem (draggedItem)) {
								draggedItem = null;
								RecalculateInventoryCount ();
								return;
							}
						} 
					} else {
						if (Swap (draggedItem, node, savedNode)) {
							draggedItem = null;
							return;
						}
					}
					
				}	
			
			} 
			savedNode.SetItem (draggedItem);
			draggedItem = null;	
			
		} 
	}
	// Do an item swap
	protected bool Swap (Item itemDest, ItemNode nodeDest, ItemNode lastNode)
	{
		if (itemDest && nodeDest) {
			Item buffer = nodeDest.GetItem ();
			if (lastNode.SetItem (buffer) && nodeDest.SetItem (itemDest)) {
				Debug.Log ("Swaped " + itemDest + " with " + buffer);
				return true;
			} else {
				return false;
			}
			
		} else {
			return false;
		}
	}
	
	// ItemNode will call this function
	public virtual void OnUse (ItemNode node)
	{
	}
	
	
}