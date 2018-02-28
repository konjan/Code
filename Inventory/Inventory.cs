using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	void Awake()
	{
		if (instance != null)
		{
			Debug.Log("Fix the Inventory");
			return;
		}

		instance = this;
	}

	public static Inventory instance;

	#endregion

	public int InventorySpace = 50;

	public List<Item> items = new List<Item>();

	public bool Add (Item item)
	{
		if (item.isStackableItem)
		{
			foreach (Item i in items)
			{
				if (item.name == i.name)
				{
					if (i.StackCount < i.StackCountMax)
					{
						i.StackCount++;
						return true;
					}
				}
			}
		}
		if (items.Count < InventorySpace)
		{
			items.Add(item);
			return true;
		}
		else
		{
			Debug.Log("Inventory Full");
			return false;
		}
	}

	public void RemoveOne (Item item)
	{
	}
	public void RemoveStack (Item item)
	{

	}

	public void IncreaseInventorySize()
	{
		InventorySpace += 10;
	}
	public void TESTResetInventorySize()
	{
		Debug.Log("Inventory Reset");
		InventorySpace = 50;
	}
}
