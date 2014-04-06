using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public class DialogWithChoices : IChainableEvent
	{

		private bool initialized;
		private EventChain event_chain_controller;

		private string[] text;
		private List<Choice> choices;
		private ushort selection;

		public DialogWithChoices( string[] text )
		{
			this.text = text;
			this.selection = 0;
			this.choices = new List<Choice>();
		}
		
		public void AddChoice( Choice choice )
		{
			this.choices.Add(choice);
		}

		public void Init( EventChain event_chain_controller )
		{
			if( this.initialized ) return;
			
			this.event_chain_controller = event_chain_controller;
			for( int i = 0; i < this.choices.Count; i++ )
				this.choices[i].Init( event_chain_controller );
			
			this.initialized = true;
		}
		
		public IEnumerator PerformChainableEvent()
		{
			this.event_chain_controller.EventComplete(this);
			yield return null;	
		}
		
		public IChainableEvent NextEvent()
		{
			return this.choices[this.selection].NextEvent;
		}
		
		public string GetName()
		{
			return "dialog with choices";
		}
		
	} // DialogWithChoices
	
} // WarOfTheThreeNations.ChainableEvents

