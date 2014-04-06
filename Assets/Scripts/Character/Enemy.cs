using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace WarOfTheThreeNations.Character
{
	
	public class Enemy : BattleCharacter
	{
	
		public Enemy( string name, ushort level, Dictionary<string, ushort> categories, Ability[] abilities )
			: base( name, level, categories, abilities )
		{
		}
		
		protected override void CharacterUnconcious()
		{
			this.unconcious = true;
			
			// 1. remove from enemy list
			// 2. start fall over
			// 3. check for win condition
			// 4. when fall over done, remove model from battle screen
		}
		
	} // Enemy

} // WarOfTheThreeNations.Character

