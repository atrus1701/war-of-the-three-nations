using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.Character.Stats;
using WarOfTheThreeNations.Battle;


namespace WarOfTheThreeNations.StatusEffects
{

	public class Blind : StatusEffect
	{
		
		public static string name = "blind";
		public static ushort duration = 1000;
		public static ushort accuracy_percentage = 50;
		
		public static bool renewable = false;
		
		public Blind( BattleCharacter character )
		{
			this.AffectCharacter( character );
			this.QueueNextEffect( character );
		}
		
		public override void ProcessEffect( BattleCharacter character, BattleCharacter[] targets )
		{
			if( !character.HasStatusEffect(Blind.name) ) return;		
			this.CureCharacter(character);
		}
		
		public override void QueueNextEffect( BattleCharacter character )
		{
			BattleQueue bq = BattleQueue.GetBattleQueue();
			bq.QueueEvent( character, null, this.ProcessEffect, Blind.duration );
		}
	
		public override void AffectCharacter( BattleCharacter character )
		{
			character.Accuracy.Current = ((uint)(character.Accuracy.Max * (Blind.accuracy_percentage * 0.01)));
		}
		
		public override void CureCharacter( BattleCharacter character )
		{
			character.Accuracy.Reset();
			character.RemoveStatusEffect(Blind.name);
		}

		public override bool IsRenewable()
		{
			return Blind.renewable;
		}
		
		public override void Renew()
		{
			// error
		}

	} // Blind

} // WarOfTheThreeNations.StatusEffects

