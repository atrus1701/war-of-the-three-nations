using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace WarOfTheThreeNations.Character
{
	
	public class PartyCharacter : BattleCharacter
	{
	
		protected Weapon weapon;
		protected Armor armor;
		
		public PartyCharacter( string name, ushort level, Dictionary<string, ushort> categories, Weapon weapon, Armor armor, Ability[] abilities )
			: base( name, level, categories, abilities )
		{
			this.weapon = weapon;
			this.armor = armor;
		}
		
		protected override void CharacterUnconcious()
		{
			this.unconcious = true;
			
			// fall over....
		}
		
	
	} // PartyCharacter

} // WarOfTheThreeNations.Character

