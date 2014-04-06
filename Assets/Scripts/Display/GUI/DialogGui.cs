﻿using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.GUI
{

	public static class DialogGui
	{
	
		private static GameObject container;
		private static GUITexture background;
		private static GUITexture image;
		private static GUIText name;
		private static GUIText text;
	
		public static void FindGuiElements( GameObject gui )
		{
			DialogGui.container = gui.transform.Find("dialog").gameObject;
			GuiHandler.SetChildrenActive( DialogGui.container, true );
			
			DialogGui.background = DialogGui.container.transform.Find("background").GetComponent<GUITexture>();
			DialogGui.image = DialogGui.container.transform.Find("image").GetComponent<GUITexture>();
			DialogGui.name = DialogGui.container.transform.Find("name").GetComponent<GUIText>();
			DialogGui.text = DialogGui.container.transform.Find("text").GetComponent<GUIText>();
			
			//GuiHandler.SetChildrenActive( DialogGui.container, false );
		}
		
		public static void ShowDialog()
		{
			DialogGui.container.gameObject.SetActive(true);
			//GuiHandler.SetChildrenActive( DialogGui.container, true );
		}
		
		public static void HideDialog()
		{
			DialogGui.container.gameObject.SetActive(false);
			//GuiHandler.SetChildrenActive( DialogGui.container, false );
		}
		
		public static GameObject Container { get { return DialogGui.container; } }
		public static GUITexture Backgound { get { return DialogGui.background; } }
		public static GUITexture Image { get { return DialogGui.image; } }
		public static GUIText Name { get { return DialogGui.name; } }
		public static GUIText Text { get { return DialogGui.text; } }
		
	} // DialogGui

} // WarOfTheThreeNations

