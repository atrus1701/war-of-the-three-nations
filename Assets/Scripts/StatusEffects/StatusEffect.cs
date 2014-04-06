using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;


namespace WarOfTheThreeNations.StatusEffects
{

	public abstract class StatusEffect
	{

		private static string name;
		private static bool renewable;
		
		public abstract void ProcessEffect( BattleCharacter character, BattleCharacter[] targets );
		public abstract void QueueNextEffect( BattleCharacter character );
		public abstract void AffectCharacter( BattleCharacter character );
		public abstract void CureCharacter( BattleCharacter character );
		
		public abstract bool IsRenewable();
		public abstract void Renew();
			
	} // StatusEffect

} // WarOfTheThreeNations.StatusEffect

