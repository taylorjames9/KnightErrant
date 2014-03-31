using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharScreen : MonoBehaviour
{
	public List<ItemNode> itemNodes = new List<ItemNode>();

	public void SetManagerForCharScreen (ItemManager manager)
	{
		int count = transform.GetChildCount ();
		for (int i = 0; i < count; ++i) {
			if (transform.GetChild (i).GetComponent<ItemNode> ()) {
				transform.GetChild (i).GetComponent<ItemNode> ().SetManager (manager);
				itemNodes.Add(transform.GetChild (i).GetComponent<ItemNode> ());
				 
			}
		}		
	}
}
