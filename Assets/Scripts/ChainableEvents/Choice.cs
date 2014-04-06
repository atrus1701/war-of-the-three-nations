using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public class Choice
	{

		private bool initialized;
		private IChainableEvent next_event;

		private string text;		

		public Choice( string text, IChainableEvent next_event )
		{
			this.next_event = next_event;
		}

		public void Init( EventChain event_chain_controller )
		{
			if( this.initialized ) return;
			
			this.next_event.Init( event_chain_controller );
			
			this.initialized = true;
		}
		
		public IChainableEvent NextEvent
		{
			get { return this.next_event; }
		}
		
	} // Choice
	
} // WarOfTheThreeNations.ChainableEvents

