using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;


namespace WarOfTheThreeNations.Battle
{

	public class BattleQueue
	{
		private static BattleQueue instance;
		
		private ArrayList queue;
		private ulong time;
		
		public delegate void BattleEventCallback( BattleCharacter character, BattleCharacter[] targets );
		
		private BattleQueue()
		{
			this.queue = new ArrayList();
			this.time = 0;
		}
		
		public static BattleQueue GetBattleQueue()
		{
			if( BattleQueue.instance == null )
				BattleQueue.instance = new BattleQueue();
			
			return BattleQueue.instance;
		}
	
		public void Clear()
		{
			this.queue.Clear();
			this.time = 0;
		}
		
		public void QueueEvent( BattleCharacter character, BattleCharacter[] targets, BattleEventCallback callback, ulong time )
		{
			ulong event_time = this.time + time;
			int insert_index = -1;
			
			if( event_time <= this.time )
			{
				insert_index = 0;
			}
			else
			{
				ulong previous_time = this.time;
				
				for( int i = 0; i < this.queue.Count; i++ )
				{
					BattleEvent be = ((BattleEvent)this.queue[i]);
					if( event_time > previous_time && event_time <= be.time )
					{
						insert_index = i;
						break;
					}
				}
				
				if( insert_index == -1 )
					insert_index = this.queue.Count;
			}
			
			this.queue.Insert( insert_index, new BattleEvent(character, targets, callback, event_time) );
		}
		
		public void NextEvent()
		{
			BattleEvent be = ((BattleEvent)this.queue[0]);
			this.queue.RemoveAt(0);
			be.PerformEvent();
		}
		
		private class BattleEvent
		{
			public BattleCharacter character;
			public BattleCharacter[] targets;
			public BattleEventCallback callback;
			public ulong time;
	
			public BattleEvent( BattleCharacter character, BattleCharacter[] targets, BattleEventCallback callback, ulong time )
			{
				this.character = character;
				this.targets = targets;
				this.callback = callback;
				this.time = time;
			}
			
			public void PerformEvent()
			{
				this.callback( this.character, this.targets );
			}
		}	                   
	
	} // BattleQueue
	
} // WarOfTheThreeNations.Battle

