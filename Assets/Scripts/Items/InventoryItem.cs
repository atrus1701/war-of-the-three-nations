using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;


namespace WarOfTheThreeNations.Items
{
	
	public class InventoryItem
	{
	
		private uint count;
		private Item data;
		
		public InventoryItem( Item item, uint count )
		{
			this.data = item;
			this.count = count;
		}
		
		public void AddItems( uint count )
		{
			this.count += count;
			if( this.count > 99 ) this.count = 99;
		}
		
		public void RemoveItems( uint count )
		{
			this.count -= count;
			if( this.count <= 0 )
			{
				ItemManager.RemoveFromInventory(this.data.Name);
			}
		}
		                      
		public void UseItem( BattleCharacter[]  characters )
		{
			this.data.UseItem( characters );
		}
	
	} // InventoryItem
	
} // WarOfTheThreeNations.Items

