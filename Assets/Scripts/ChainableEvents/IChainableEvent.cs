using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.ChainableEvents
{
	
	public interface IChainableEvent
	{
		
		void Init( EventChain event_chain_controller );
		IEnumerator PerformChainableEvent();
		IChainableEvent NextEvent();
		
		string GetName();
		
	} // IChainableEvent
	
} // WarOfTheThreeNations.ChainableEvents

