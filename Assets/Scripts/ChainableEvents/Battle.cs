using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public class Battle : IChainableEvent
	{
	
		private bool initialized;
		private EventChain event_chain_controller;
		private IChainableEvent next_event;

		public Battle()
		{
			
		}

		public void Init( EventChain event_chain_controller )
		{
			if( this.initialized ) return;

			this.event_chain_controller = event_chain_controller;
			if( this.next_event != null )
				this.next_event.Init( event_chain_controller );

			this.initialized = true;
		}
		
		
		public void AddChainableEvent( IChainableEvent next_event )
		{
			this.next_event = next_event;
		}

		public IEnumerator PerformChainableEvent()
		{
			this.event_chain_controller.EventComplete(this);
			yield return null;	
		}
		
		public IChainableEvent NextEvent()
		{
			return this.next_event;
		}
		
		public string GetName()
		{
			return "battle";
		}
		
	} // Battle

} // WarOfTheThreeNations.ChainableEvents

