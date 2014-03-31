using UnityEngine;
using System.Collections;

public class Armor : Equip
{
	[SerializeField]
	ArmorType m_armorType;
	 
	public ArmorType armorType { get { return m_armorType; } protected set { m_armorType = value; } }
	
}
