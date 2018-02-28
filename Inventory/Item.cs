using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory")]
public class Item : ScriptableObject
{
	new public string name = "ItemName";
	public Sprite icon = null;

	//Stackable
	public bool isStackableItem = false;
	public int StackCount = 0;
	public int StackCountMax = 10;
}
