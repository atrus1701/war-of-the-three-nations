using UnityEngine;
using System.Collections;


namespace WarOfTheThreeNations.Controller
{

	[RequireComponent(typeof (Animator))]
	[RequireComponent(typeof (CapsuleCollider))]
	[RequireComponent(typeof (Rigidbody))]
	
	public class CharacterController : MonoBehaviour
	{
		private Animator animator;
	
		public float walk_animation_speed = 1.0f;
		public float run_animation_speed = 1.0f;
		
		public float walk_speed = 0.5f;
		public float run_speed = 1.0f;
		
		public float angle_north = 0.0f;
		
		public bool disable_running = false;
		
		private float speed = 0.0f;
	
	
	
		void Start ()
		{
			EventManager.OnGameStateChange += this.ChangeState;
			
			this.animator = GetComponent<Animator>();
			if( this.animator.layerCount == 2 )
				this.animator.SetLayerWeight( 1, 1 );
		}
		
		void FixedUpdate()
		{
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			
			Vector3 axis_vector = new Vector3( h, 0, v );
			float new_speed = Vector3.Magnitude( axis_vector );
			
			float animation_speed = 1.0f;
			if( new_speed < 0.1 )
			{
				this.speed = 0.0f;
			}
			else if( new_speed < 0.85 )
			{
				this.speed = walk_speed;
				animation_speed = walk_animation_speed;
			}
			else if( !this.disable_running )
			{
				this.speed = run_speed;
				animation_speed = run_animation_speed;
			}
			else 
			{
				this.speed = walk_speed;
				animation_speed = walk_animation_speed;
				new_speed = 0.80f;
			}
	
			if( this.speed > 0 )
			{
				axis_vector.Normalize();
				float forward_axis = Vector3.Angle(Vector3.forward, axis_vector);
				if( axis_vector.x < 0 ) forward_axis = 360 - forward_axis;
				float total_angle = this.angle_north + forward_axis;
	
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, total_angle, transform.eulerAngles.z);
			}
					
			Vector3 new_position = transform.position;
			new_position += transform.forward * this.speed;
			transform.position = new_position;
			
			animator.SetFloat( "Speed", new_speed );
			animator.speed = animation_speed;
		}
		
		public void ChangeState( GameState previous_state, GameState new_state )
		{
			if( new_state != GameState.PLAY )
				this.enabled = false;
			else
				this.enabled = true;
		}
		
	} // CharacterController

} // WarOfTheThreeNations.Controller

