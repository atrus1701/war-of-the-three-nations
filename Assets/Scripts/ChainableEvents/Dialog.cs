using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.GUI;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public class Dialog : IChainableEvent
	{
		
		private bool initialized;
		private EventChain event_chain_controller;
		private IChainableEvent next_event;
		
		private string character_name;
		private string[] text;

		private bool text_is_scrolling;
		private string displayed_text;
		private bool all_text_displayed;
		
		public static uint scroll_speed = 20;

		public Dialog( string character_name, string[] text )
		{
			this.character_name = character_name;
			this.text = text;
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
			Game.State = GameState.SCENE;
			this.all_text_displayed = false;
			this.text_is_scrolling = true;
			this.displayed_text = "";
			DialogGui.Name.text = this.character_name;
			DialogGui.Text.text = "";
			// set image
			DialogGui.ShowDialog();
			
			for( int l = 0; l < this.text.Length; l++ )
			{
				for( int c = 0; c < this.text[l].Length; c++ )
				{
					if( this.text_is_scrolling )
					{
						this.displayed_text += this.text[l][c];
						DialogGui.Text.text = displayed_text;
						yield return new WaitForSeconds( (float)(1 / Dialog.scroll_speed) );
					}
					
					if( Input.GetButtonUp("Confirm") )
					{
						this.text_is_scrolling = false;
						yield return new WaitForSeconds(0.0f);
						break;
					}
				}
				
				if( !this.text_is_scrolling ) break;
				this.displayed_text += "\n";
			}
			
			if( !this.text_is_scrolling )
			{
				this.displayed_text = "";
				
				for( int l = 0; l < this.text.Length; l++ )
				{
					this.displayed_text += this.text[l] + "\n";
				}
				
				DialogGui.Text.text = this.displayed_text;
			}
						
			while( !Input.GetButtonUp("Confirm") )
			{
				yield return new WaitForSeconds(0.0f);
			}
			
			// hide dialog
			DialogGui.HideDialog();
			
			this.event_chain_controller.EventComplete(this);
			yield return null;
		}
		
		public IChainableEvent NextEvent()
		{
			return this.next_event;
		}
		
		public string GetName()
		{
			return "dialog";
		}
		
	} // Dialgo
	
} // WarOfTheThreeNations.ChainableEvents

