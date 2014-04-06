using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.StatusEffects;


namespace WarOfTheThreeNations.Effects
{

	public class StatusEffect
	{
	
		private StatusEffectAction action;
		private string status_effect;
		
		public StatusEffect( StatusEffectAction action, string status_effect )
		{
			this.action = action;
			this.status_effect = status_effect;
		}
		
		public void AffectCharacters( BattleCharacter[] characters )
		{
			foreach( BattleCharacter bc in characters )
			{
				switch( this.action )
				{
					case( StatusEffectAction.ADD ):
						bc.AddStatusEffect( this.status_effect );
						break;
						
					case( StatusEffectAction.REMOVE ):
						bc.RemoveStatusEffect( this.status_effect );
						break;
				}
			}
		}
	
	} // StatusEffect

} // WarOfTheThreeNations.Effects

