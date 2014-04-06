using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;


namespace WarOfTheThreeNations.StatusEffects
{
	
	public static class StatusEffectManager
	{
		
		public static StatusEffect GetStatusEffect( string name, BattleCharacter character )
		{
			if( name == Poison.name )
				return new Poison(character);
			else if( name == Blind.name )
				return new Blind(character);
			
			// generate error
			return null;
		}
		
	} // StatusEffectManager
	
} // WarOfTheThreeNations.StatusEffect

