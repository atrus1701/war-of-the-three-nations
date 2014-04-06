using UnityEngine;
using System;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.Character.Stats;

namespace WarOfTheThreeNations
{
	
	public enum GameState
	{
		MAIN_MENU,
		PAUSE,
		IN_GAME_MENU,
		SAVE_MENU,
		LOAD_MENU,
		LOAD_SCREEN,
		SCENE,
		BATTLE,
		SHOP,
		BLACKSMITH,
		PLAY
	}
	
	public static class Game
	{
		
		private static GameState state = GameState.PLAY;

		public static GameState State
		{
			get { return Game.state; }
			set {
				GameState old_state = Game.state;
				Game.state = value;
				EventManager.InvokeOnGameStateChange( old_state, value );
			}
		}
		
	} // Game
	
} // WarOfTheThreeNations

