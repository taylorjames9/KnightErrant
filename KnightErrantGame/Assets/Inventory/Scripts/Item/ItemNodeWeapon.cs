using UnityEngine;
using System.Collections;

public class ItemNodeWeapon : ItemNode
{

	[SerializeField]
	public WeaponType onlyAcceptThisType;
	
	public override bool SetItem (Item item)
	{

		if (item is Weapon) {
			if ((item as Weapon).weaponType == onlyAcceptThisType) {
				base.SetItem (item);
				return true;
			} 
		} 
		return false;
	}
}
