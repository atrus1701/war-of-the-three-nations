using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.Battle;

namespace WarOfTheThreeNations.StatusEffects
{

	public class Poison : StatusEffect
	{
	
		public static string name = "poison";
		public static ushort speed = 100;
		public static ushort duration = 1000;
		public static short[] damage_percent = new short[] { 5, 10 };

		public static bool renewable = false;
		
		private ulong time;
		
		public Poison( BattleCharacter bc )
		{
			this.time = 0;
			this.QueueNextEffect( bc );
		}
		
		public override void ProcessEffect( BattleCharacter character, BattleCharacter[] targets )
		{
			if( !character.HasStatusEffect(Poison.name) ) return;
			
			this.AffectCharacter( character );
			
			this.time += Poison.speed;
			if( this.time >= Poison.duration )
			{
				this.CureCharacter( character );
			}
			else
			{
				this.QueueNextEffect( character );
			}
		}
		
		public override void QueueNextEffect( BattleCharacter character )
		{
			BattleQueue bq = BattleQueue.GetBattleQueue();
			bq.QueueEvent( character, null, this.ProcessEffect, Poison.speed );
		}
		
		public override void AffectCharacter( BattleCharacter character )
		{
			int random_percentage = Random.Range( Poison.damage_percent[0], Poison.damage_percent[1] );
			float damage = character.MaxHP * (random_percentage / 0.01f);
			character.TakeDamage( ((int)damage) );
		}
		
		public override void CureCharacter( BattleCharacter character )
		{
			character.RemoveStatusEffect(Poison.name);
		}
		
		public override bool IsRenewable()
		{
			return Poison.renewable;
		}
		
		public override void Renew()
		{
			// error
		}

	} // Poison

} // WarOfTheThreeNations.StatusEffects

