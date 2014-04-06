using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.Character.Stats
{

	public class AttackStat : Stat
	{
		
		public static string name = "atk";
		
		public AttackStat( ushort level, ushort category, uint initial_value )
			: base( level, category, initial_value )
		{
			
		}
	
		public override void UpdateValue( ushort level )
		{
			uint value = 0;
			
			// calculate max and current values based on level and category.
			switch( this.category )
			{
				
			case( 0 ):
				break;
				
			case( 1 ):
				break;
				
			case( 2 ):
				break;
				
			case( 3 ):
				break;
				
			case( 4 ):
				break;
				
			case( 5 ):
				break;
				
			case( 6 ):
				break;
				
			case( 7 ):
				break;
				
			case( 8 ):
				break;
				
			case( 9 ):
				break;
				
			}
			
			this.max_value = this.initial_value + value;
			this.Reset();
		}
		
	} // AttackStat

} // WarOfTheThreeNations.Character.Stats

