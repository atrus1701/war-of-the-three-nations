using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public class ChangeLocation : IChainableEvent
	{

		private bool initialized;
		private EventChain event_chain_controller;
		private IChainableEvent next_event;
		
		private string scene_name;
		
		public ChangeLocation( string scene_name )
		{
			this.scene_name = scene_name;
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
			Debug.Log ("performing change location" );
			Game.State = GameState.LOAD_SCREEN;
			Application.LoadLevel(this.scene_name);
			
			// load screen?
			
			this.event_chain_controller.EventComplete(this);
			yield return null;	
		}
		
		public IChainableEvent NextEvent()
		{
			return this.next_event;
		}

		
		public string GetName()
		{
			return "change location";
		}
		
	} // ChangeLocation
	
} // WarOfTheThreeNations.ChainableEvents

