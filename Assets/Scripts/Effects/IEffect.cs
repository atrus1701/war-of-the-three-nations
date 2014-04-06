using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Character;


namespace WarOfTheThreeNations.Effects
{

	public interface IEffect
	{
	
		void AffectCharacters( BattleCharacter[] characters );

	} // IEffect

} // WarOfTheThreeNations.Effects

