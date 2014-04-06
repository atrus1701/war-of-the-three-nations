using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;


namespace WarOfTheThreeNations.Battle
{
	
	public class Formation
	{
		private short[][] formation;
		private ushort front_row;
		private ushort back_row;
	
		public Formation( short[][] formation )
		{
			this.formation = formation;
			this.FindFrontRow();
			this.FindBackRow();
		}
		
		public Formation( 
			short row1col1, short row1col2, short row1col3, 
		    short row2col1, short row2col2, short row2col3, 
		    short row3col1, short row3col2, short row3col3 )
		{
			this.formation = new short[][] {
				new short[] { row1col1, row1col2, row1col3 },
				new short[] { row2col1, row2col2, row2col3 },
				new short[] { row3col1, row3col2, row3col3 }
			};
			this.FindFrontRow();
			this.FindBackRow();
		}
		
		private void FindFrontRow()
		{
			for( ushort r = 0; r < this.formation.Length; r++ )
			{
				bool row_is_empty = true;
				for( ushort c = 0; c < this.formation[r].Length; c++ )
				{
					if( this.formation[r][c] > -1 )
					{
						row_is_empty = false;
						break;
					}
				}
				
				if( !row_is_empty )
				{
					this.front_row = r;
					return;
				}
			}
			
			// generate error
		}
		
		private void FindBackRow()
		{
			for( ushort r = (ushort)(this.formation.Length - 1); r >= 0; r-- )
			{
				bool row_is_empty = true;
				for( ushort c = 0; c < this.formation[r].Length; c++ )
				{
					if( this.formation[r][c] > -1 )
					{
						row_is_empty = false;
						break;
					}
				}
				
				if( !row_is_empty )
				{
					this.back_row = r;
					return;
				}
			}
			
			// generate error
		}
		
		public bool InFrontRow( short index )
		{
			return this.InRow( this.front_row, index );
		}
		
		public bool InBackRow( short index )
		{
			return this.InRow( this.back_row, index );
		}
		
		public bool InRow( ushort row, short index )
		{
			for( ushort c = 0; c < this.formation[row].Length; c++ )
			{
				if( this.formation[row][c] == index )
					return true;
			}
			
			return false;
		}
		
		public bool InColumn( ushort column, short index )
		{
			for( ushort r = 0; r < this.formation.Length; r++ )
			{
				if( this.formation[r][column] == index )
					return true;
			}
			
			return false;
		}
		
		public short[] GetRow( short index )
		{
			return this.formation[index];
		}
		
		public short[] GetColumn( short index )
		{
			short[] column = new short[3];
			
			for( ushort r = 0; r < this.formation.Length; r++ )
			{
				column[r] = this.formation[r][index];
			}
			
			return column;
		}

	} // Formation

} // WarOfTheThreeNations.Battle

