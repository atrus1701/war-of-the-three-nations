using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.Controller
{

	[RequireComponent(typeof (CharacterController))]
	
	public class CharacterCamera : MonoBehaviour
	{
		
		public Camera player_camera;
		
		private CharacterController controller;
		private float north = 0.0f;
		
		public float distance_back = 20.0f;
		public float distance_above = 40.0f;
		
		
		// Use this for initialization
		void Start()
		{
			EventManager.OnGameStateChange += this.ChangeState;
			
			if( !this.player_camera )
				this.player_camera = Camera.main;
			
			this.controller = transform.GetComponent<CharacterController>();
		}
		
		// Update is called once per frame
		void Update()
		{
			this.north = this.controller.angle_north;
			this.player_camera.transform.eulerAngles = new Vector3( 0, this.north, 0 );
			Vector3 new_transform = transform.position;
			new_transform += (-this.player_camera.transform.forward * this.distance_back);
			new_transform += (this.player_camera.transform.up * this.distance_above);
			this.player_camera.transform.position = new_transform;
			this.player_camera.transform.LookAt(transform.position);
		}
		
		public Transform getCameraTransform()
		{
			if( this.player_camera ) return this.player_camera.transform;
			return Camera.main.transform;
		}
		
		public void ChangeState( GameState previous_state, GameState new_state )
		{
			if( new_state != GameState.PLAY )
				this.enabled = false;
			else
				this.enabled = true;
		}
		
	} // CharacterCamera
	
} // WarOfTheThreeNations.Controller

