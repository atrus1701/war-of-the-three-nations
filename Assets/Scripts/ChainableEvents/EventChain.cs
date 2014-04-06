using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public enum EventTrigger
	{
		INTERACT,
		ENTER,
		EXIT
	}
	
	public class EventChain : MonoBehaviour
	{
		
		private EventTrigger trigger;
		private bool is_repeatable;
		private bool is_completed;
		private bool processing_event_chain;
		
		private IChainableEvent first_event;
		private IChainableEvent current_event;
		
		public void Start()
		{
			this.first_event = EventDataManager.GetChainableEvents( "" );
			this.current_event = null;
			this.trigger = EventTrigger.INTERACT;
			this.is_repeatable = false;
			this.is_completed = false;
			this.processing_event_chain = false;
		
			this.first_event.Init( this );
		}
		
		public void Update()
		{
			if( this.current_event != null )
			{
				Debug.Log ("performing current event : "+this.current_event.GetName());
				StartCoroutine ( this.current_event.PerformChainableEvent() );
				this.current_event = null;
			}
		}
		
		public void EventComplete( IChainableEvent current_event )
		{
			Debug.Log ("done with event");
			this.current_event = current_event.NextEvent();
			
			if( this.current_event == null )
			{
				// finish
				Debug.Log ("event chain completed");
				this.processing_event_chain = false;
				this.is_completed = true;
				Game.State = GameState.PLAY;
			}
		}
		
		public void OnTriggerEnter( Collider collider )
		{
			if( Game.State != GameState.PLAY ) return;
			if( collider.tag != "Player" ) return;
			if( this.processing_event_chain ) return;
			if( this.trigger != EventTrigger.ENTER ) return;
			if( this.is_completed && !this.is_repeatable ) return;

			this.processing_event_chain = true;
			this.current_event = this.first_event;
		}
		
		public void OnTriggerExit( Collider collider )
		{
			if( Game.State != GameState.PLAY ) return;
			if( collider.tag != "Player" ) return;
			if( this.processing_event_chain ) return;
			if( this.trigger != EventTrigger.EXIT ) return;
			if( this.is_completed && !this.is_repeatable ) return;
			
			this.processing_event_chain = true;
			this.current_event = this.first_event;
		}
		
		public void OnTriggerStay( Collider collider )
		{
			if( Game.State != GameState.PLAY ) return;
			if( collider.tag != "Player" ) return;
			if( this.processing_event_chain ) return;
			if( this.trigger != EventTrigger.INTERACT ) return;
			if( this.is_completed && !this.is_repeatable ) return;
			if( !Input.GetButtonUp("Confirm") ) return;

			Debug.Log ("starting");
			this.processing_event_chain = true;
			this.current_event = this.first_event;
		}
		
	} // EventChain
	
} // WarOfTheThreeNations.ChainableEvents

