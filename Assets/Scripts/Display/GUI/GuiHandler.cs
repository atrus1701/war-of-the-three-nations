using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.GUI
{
	
	public class GuiHandler : MonoBehaviour
	{
		
		// Use this for initialization
		void Start()
		{
			GameObject gui = GameObject.Find("gui");
			GuiHandler.SetChildrenActive(gui, true);
			
			DialogGui.FindGuiElements( gui );
			
			GuiHandler.SetChildrenActive(gui, false);
		}
		
		
		public static void SetChildrenActive( GameObject parent, bool active )
		{
			foreach( Transform child in parent.transform )
			{
				child.gameObject.SetActive(active);
			} 
		}
		
	} // GuiHandler
	
} // WarOfTheThreeNations

