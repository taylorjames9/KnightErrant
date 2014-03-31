using UnityEngine;
using System.Collections;

public class Weapon : Equip
{
	[SerializeField]
	WeaponType m_weaponType;
	 
	public WeaponType weaponType { get { return m_weaponType; } protected set { m_weaponType = value; } }

	
}
