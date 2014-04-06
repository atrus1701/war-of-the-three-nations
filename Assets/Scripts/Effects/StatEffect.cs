using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.Character.Stats;


namespace WarOfTheThreeNations.Effects
{

	public class StatEffect : IEffect
	{

		private string stat;
		private ValueType value_type;
		private int value;
		
		public StatEffect( string stat, ValueType value_type, int value )
		{
			this.stat = stat;
			this.value_type = value_type;
			this.value = value;
		}
		
		public void AffectCharacters( BattleCharacter[] characters )
		{
			foreach( BattleCharacter bc in characters )
			{
				Stat stat = bc.GetStat( this.stat );
				switch( this.value_type )
				{
					case( ValueType.PERCENTAGE_MAX ):
						float mpercentage = stat.Max * (this.value * 0.01f);
					stat.Current += (uint)mpercentage;
						break;
						
					case( ValueType.PERCENTAGE_CURRENT ):
						float cpercentage = stat.Current * (this.value * 0.01f);
						stat.Current += (uint)cpercentage;
						break;
						
					case( ValueType.STATIC ):
						long new_current = stat.Current + value;
						stat.Current = (uint)new_current;
						break;
				}
			}
		}

	} // StatEffect

} // WarOfTheThreeNations.Effects

