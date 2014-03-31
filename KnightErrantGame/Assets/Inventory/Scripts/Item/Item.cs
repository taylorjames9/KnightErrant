using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{

	ItemLevel m_itemLevel;
	string m_itemName;
	float m_itemValue;
	[SerializeField]
	public Material icon;
	
	public float itemValue { get { return m_itemValue; } protected set { m_itemValue = value; } }

	public string itemName { get { return m_itemName; } protected set { m_itemName = value; } }

	public ItemLevel itemLevel { get { return m_itemLevel; } protected set { m_itemLevel = value; } }

	public virtual void  OnUse ()
	{
	
	}


	
}
