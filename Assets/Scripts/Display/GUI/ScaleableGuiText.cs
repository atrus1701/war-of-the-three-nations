using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Display;


namespace WarOfTheThreeNations.Display.GUI
{
	
	[RequireComponent(typeof (GUIText))]
	[ExecuteInEditMode]
	public class ScaleableGuiText : MonoBehaviour
	{
		
		private GUIText text;
		public bool update_every_frame = true;
		public Vector2 position = new Vector2();
		public int font_size = 12;
		public ScaleType scale = ScaleType.SCALE;
		
		public void Awake()
		{
			this.text = this.transform.GetComponent<GUIText>();
			EventManager.OnScreenChange += this.RepositionAndScale;
		}
		
		public void Start()
		{
			this.RepositionAndScale();
		}
		
		public void Update()
		{
			if( this.update_every_frame )
				this.RepositionAndScale();
		}
		
		private void RepositionAndScale()
		{
			transform.position = new Vector3( 0, 0, transform.position.z );
			transform.rotation = new Quaternion();
			transform.localScale = new Vector3();
			
			Vector2 position = ScreenManager.GuiGetAdjustedPosition( new Vector2( this.position.x, this.position.y ) );
			int font_size = this.font_size;
			
			switch( this.scale )
			{
				case( ScaleType.SCALE ):
					font_size = (int)(ScreenManager.ScaleValue( (float)this.font_size ));
					break;
					
				case( ScaleType.ORIGINAL ):
				case( ScaleType.NONE ):
					
					break;
			}
			
			Vector3 transform_position = transform.position;
			switch( this.text.anchor )
			{
				case( TextAnchor.UpperLeft ):
					transform_position.y = 1.0f;
					break;
					
				case( TextAnchor.UpperCenter ):
					transform_position.x = 0.5f;
					transform_position.y = 1.0f;
					break;
					
				case( TextAnchor.UpperRight ):
					transform_position.x = 1.0f;
					transform_position.y = 1.0f;
					break;
					
				case( TextAnchor.MiddleLeft ):
					transform_position.y = 0.5f;
					break;
					
				case( TextAnchor.MiddleCenter ):
					transform_position.x = 0.5f;
					transform_position.y = 0.5f;
					break;
					
				case( TextAnchor.MiddleRight ):
					transform_position.x = 1.0f;
					transform_position.y = 0.5f;
					break;
					
				case( TextAnchor.LowerLeft ):
					break;
					
				case( TextAnchor.LowerCenter ):
					transform_position.x = 0.5f;
					break;
					
				case( TextAnchor.LowerRight ):
					transform_position.x = 1.0f;
					break;
			}
			
			transform.position = transform_position;
			this.text.pixelOffset = position;
			this.text.fontSize = (int)font_size;
		}
		
	} // ScaleableGuiTexture
	
} // WarOfTheThreeNations.Display.GUI

