using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.Character.Stats
{

	public abstract class Stat
	{
		protected uint max_value;
		protected uint current_value;
		
		protected ushort category;
		protected uint initial_value;
			
	
		protected Stat( ushort level, ushort category, uint initial_value )
		{
			this.category = category;
			this.initial_value = initial_value;
			this.UpdateValue( level );
		}
		
		public abstract void UpdateValue( ushort level );
		
		public uint Max
		{
			get { return this.max_value; }
		}
		
		public uint Current
		{
			get { return this.current_value; }
			set { this.current_value = value; }
		}
		
		public void Reset()
		{
			this.current_value = this.max_value;
		}
		
	} // Stat

} // WarOfTheThreeNations.Character.Stats

