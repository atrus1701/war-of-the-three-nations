using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.Battle
{
	
	public class BattleManager
	{
	
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		void OnTriggerEnter(Collider collider) {
			Debug.Log ("OnTriggerEnter");
			
			// TODO: check if player character
			
			//this.LoadLevelAsync();
			
			Application.LoadLevelAdditive("battle-grass-plain");
			
			Debug.Log ("LoadLevelAdditive done?");
			
			//		GameObject battle_scene = null;
			//		while ((battle_scene = GameObject.Find( "battle-scene-container" )) == null);
			//		battle_scene.renderer.enabled = false;
			
			GameObject container = GameObject.Find ( "overworld-scene-container" );
			
			if (container == null)
				Debug.Log ("container is null");
			else
				Debug.Log ("got container");
			
			container.SetActive (false);
			
			GameObject battle_camera = GameObject.Find ("battle-camera");
			
			if (battle_camera == null) {
				Debug.Log ("making camera");
				battle_camera = new GameObject();
				//Instantiate(battle_camera);
			}
			
			if (battle_camera == null)
				Debug.Log ("no battle camera");
			else
				Debug.Log ("got battle camera");
			
		}
		
		IEnumerator LoadLevelAsync()
		{
			AsyncOperation async = Application.LoadLevelAdditiveAsync("battle-grass-plain");
			yield return async;
			
			Debug.Log("Loading complete");
			
			//Application.LoadLevelAdditive( "battle-grass-plain" );
			
			GameObject battle_scene = GameObject.Find( "battle-scene-container" );
			battle_scene.renderer.enabled = false;
		}

	} // BattleManager

} // WarOfTheThreeNations.Battle

