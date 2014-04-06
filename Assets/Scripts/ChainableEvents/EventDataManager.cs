using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.ChainableEvents
{
	public static class EventDataManager
	{
		
		public static IChainableEvent GetChainableEvents( string name )
		{
			Debug.Log ("creating dialog event");
			Dialog event1 = new Dialog( "George" , new string[] {
				"This is the first line of text.",
				"This is the next line of text.",
				"This is a very long line of text used for testing the scrolling effect.",
				"This is a very long line of text used for testing the scrolling effect."
			});
			
			Debug.Log ("creating change location event");
			ChangeLocation event2 = new ChangeLocation( "karak-village" );

			Debug.Log ("adding change location to dialog");
			event1.AddChainableEvent( event2 );			
			
			Dialog event3 = new Dialog( "Town Greeter", new string[] {
				"Welcome to Karak Village!"
			});
			
			event2.AddChainableEvent( event3 );
			
			Debug.Log( "returning dialog event");
			return event1;
		}
		
	} // EventDataManager

} // WarOfTheThreeNations.ChainableEvents

