using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.Effects;


namespace WarOfTheThreeNations.Items
{
	
	public abstract class Item
	{
		
		protected string name;
		protected uint cost;
		protected IEffect[] effects;
		
		public void UseItem( BattleCharacter[] characters )
		{
			foreach( IEffect e in effects )
			{
				e.AffectCharacters( characters );
			}
		}
		
		public string Name
		{
			get { return this.name; }
		}
		
		public uint Cost
		{
			get { return this.cost; }
		}
		
	} // Item
	
} // WarOfTheThreeNations.Items

