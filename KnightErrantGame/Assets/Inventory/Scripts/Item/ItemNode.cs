using UnityEngine;
using System.Collections;

public class ItemNode : MonoBehaviour
{
	[SerializeField]
	protected Material background;
	protected ItemManager manager;
	protected Item item;
	protected Texture2D texture;
	[SerializeField]
	Overlay overlay;
	Overlay o;
	Rect position;
	bool isDragging;
	
	float textureHeight = 40.0f;
	float textureWidth = 40.0f;

	void Start ()
	{
		SetBackground ();
	}
	
	public void SetManager (ItemManager manager)
	{
		this.manager = manager;
	}

	public virtual bool  SetItem (Item item)
	{
	
		if (item) {
			this.item = item;
			renderer.material = item.icon;
			texture = item.icon.mainTexture as Texture2D;	
			return true;		
		} else {
			return false;
		}
// *** Stacking will be implemented soon ***
// *********************************
//			if (item is UseableItem) {
//				TextMesh t = Instantiate (stackSize) as TextMesh;
//				t.text = (item as UseableItem).GetStackSize ().ToString ();
//				t.transform.position = transform.position;
//				
//			}
			
		
		
	}

	public Item GetItem ()
	{
		return item;
	}

	public void RemoveItem ()
	{
		item = null;
		SetBackground ();
	}
	
	void SetBackground ()
	{
		renderer.material = background;
	}

	protected virtual void OnMouseDrag ()
	{
		if (item && manager) {
			isDragging = true;
			manager.OnDrag (this);
     		
			
		}
	}
	
	void OnGUI ()
	{
		if (isDragging) {
			if (texture) {
				position = new Rect (Input.mousePosition.x - (textureWidth / 2), (Screen.height - Input.mousePosition.y) - (textureHeight / 2), textureWidth, textureHeight);
				GUI.DrawTexture (position, texture);
			} else {
				Debug.LogError ("No Texture - NullPointer");
			}
		}
	}

	void OnMouseUp ()
	{
		if (manager) {
			isDragging = false;
			manager.OnDragEnded ();
		}
	}
	
	// Spawns the mouseoverlay
	void OnMouseEnter ()
	{
		o = Instantiate (overlay) as Overlay;
		o.SetOverlay (this);
		
		
	}
	// destroys the mouseoverlay
	void OnMouseExit ()
	{
		Destroy (o.gameObject);
	}
	
	// Calls OnUse function in ItemManager
	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (1)) {
			if (item && item is Equip) {
				manager.OnUse (this);
			}
		}
	}
	

	
}
