using UnityEngine;
using System.Collections;

public class Overlay : MonoBehaviour
{


	public void SetOverlay (ItemNode node)
	{
		if (node) {
			transform.localPosition = node.transform.position;
			transform.localScale = node.transform.lossyScale;
			transform.rotation = node.transform.rotation;
			transform.parent = node.transform.parent;
		} else {
			Debug.Log ("Overlay Nullpointer");
		}
	}
}