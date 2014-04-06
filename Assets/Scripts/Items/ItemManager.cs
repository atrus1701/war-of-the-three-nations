using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WarOfTheThreeNations.Items
{
	
	public static class ItemManager
	{
		
		private static Dictionary<string, Item> all_items = new Dictionary<string, Item>();
		private static Dictionary<string, InventoryItem> inventory = new Dictionary<string, InventoryItem>();
		
		
		public static void RemoveFromInventory( string name )
		{
			ItemManager.inventory.Remove(name);
		}
		
		public static void AddItems( string name, uint amount )
		{
			if( ItemManager.inventory.ContainsKey(name) )
			{
				ItemManager.inventory[name].AddItems( amount );
			}
			else
			{
				ItemManager.inventory.Add( name, new InventoryItem(ItemManager.all_items[name], amount) );
			}
		}
		
		
		
	} // ItemManager
	
} // WarOfTheThreeNations.Items

