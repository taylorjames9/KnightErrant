using UnityEngine;
using System.Collections;

public class ItemNodeArmor : ItemNode
{

	[SerializeField]
	public ArmorType onlyAcceptThisType;
	
	public override bool SetItem (Item item)
	{
		if (item is Armor) {
			if ((item as Armor).armorType == onlyAcceptThisType) {
				base.SetItem (item);
				return true;
			}
		}
		return false;
	}

	
	
	
}