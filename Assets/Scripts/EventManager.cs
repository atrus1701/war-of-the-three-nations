using UnityEngine;
using System;
using WarOfTheThreeNations.Character;
using WarOfTheThreeNations.Character.Stats;

namespace WarOfTheThreeNations
{

	public static class EventManager
	{
		
		public delegate void GameStateChange( GameState previous_state, GameState new_state );
		public delegate void CharacterStatChange( BattleCharacter character, int amount );
		public delegate void ScreenChange();
		
		
		public static event GameStateChange OnGameStateChange;
		public static void InvokeOnGameStateChange( GameState previous_state, GameState new_state )
		{
			if( EventManager.OnGameStateChange != null )
				EventManager.OnGameStateChange( previous_state, new_state );
		}
		
		public static event CharacterStatChange OnCharacterHPChange;
		public static void InvokeOnCharacterHPChange( BattleCharacter character, int amount )
		{
			if( EventManager.OnCharacterHPChange != null )
				EventManager.OnCharacterHPChange( character, amount );
		}
		
		public static event CharacterStatChange OnCharacterMPChange;
		public static void InvokeOnCharacterMPChange( BattleCharacter character, int amount )
		{
			if( EventManager.OnCharacterMPChange != null )
				EventManager.OnCharacterMPChange( character, amount );
		}
		
		public static event ScreenChange OnScreenChange;
		public static void InvokeOnScreenChange()
		{
			if( EventManager.OnScreenChange != null )
				EventManager.OnScreenChange();
		}
		
	} // EventManager
		
} // WarOfTheThreeNations

