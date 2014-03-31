using UnityEngine;
using System.Collections;

public class UseableItem : Item
{
	
	int stackSize;
	
	public void AddToStack ()
	{
		++stackSize;	
	}

	public int GetStackSize ()
	{
		return stackSize;
	}

}
