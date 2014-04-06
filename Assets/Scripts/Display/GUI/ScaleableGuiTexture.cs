using UnityEngine;
using System.Collections;
using WarOfTheThreeNations.Display;


namespace WarOfTheThreeNations.Display.GUI
{

	public enum ScaleType
	{
		SCALE,
		ORIGINAL,
		NONE
	}
	
	[RequireComponent(typeof (GUITexture))]
	[ExecuteInEditMode]
	public class ScaleableGuiTexture : MonoBehaviour
	{
		
		private GUITexture texture;
		public TextAnchor anchor = TextAnchor.UpperLeft;
		public Rect size = new Rect();
		public bool update_every_frame = true;
		public ScaleType scale = ScaleType.SCALE;
		
		public void Awake()
		{
			this.texture = this.transform.GetComponent<GUITexture>();
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
			
			Vector2 position = ScreenManager.GuiGetAdjustedPosition( new Vector2( this.size.x, this.size.y ) );
			Vector2 size = new Vector2();
			
			switch( this.scale )
			{
				case( ScaleType.SCALE ):
					size = ScreenManager.GuiGetAdjustSize( new Vector2( this.size.width, this.size.height ) );
					break;
					
				case( ScaleType.ORIGINAL ):
					size = new Vector2( this.texture.texture.width, this.texture.texture.height );
					break;
					
				case( ScaleType.NONE ):
					size = new Vector2( this.size.width, this.size.height );
					break;
			}
			
			Vector3 transform_position = transform.position;
			switch( this.anchor )
			{
			case( TextAnchor.UpperLeft ):
				transform_position.y = 1.0f;
				position.y -= size.y;
				break;
				
			case( TextAnchor.UpperCenter ):
				transform_position.x = 0.5f;
				transform_position.y = 1.0f;
				position.x -= size.x / 2;
				position.y -= size.y;
				break;
				
			case( TextAnchor.UpperRight ):
				transform_position.x = 1.0f;
				transform_position.y = 1.0f;
				position.x -= size.x;
				position.y -= size.y;
				break;
				
			case( TextAnchor.MiddleLeft ):
				transform_position.y = 0.5f;
				position.y -= size.y / 2;
				break;
				
			case( TextAnchor.MiddleCenter ):
				transform_position.x = 0.5f;
				transform_position.y = 0.5f;
				position.x -= size.x / 2;
				position.y -= size.y / 2;
				break;
				
			case( TextAnchor.MiddleRight ):
				transform_position.x = 1.0f;
				transform_position.y = 0.5f;
				position.x -= size.x;
				position.y -= size.y / 2;
				break;
				
			case( TextAnchor.LowerLeft ):
				break;
				
			case( TextAnchor.LowerCenter ):
				transform_position.x = 0.5f;
				position.x -= size.x / 2;
				break;
				
			case( TextAnchor.LowerRight ):
				transform_position.x = 1.0f;
				position.x -= size.x;
				break;
			}
			
			transform.position = transform_position;
			
			//			switch( this.anchor )
			//			{
//			case( TextAnchor.UpperLeft ):
//				position.y = ScreenManager.ScreenHeight - position.y - size.y;
//				break;
//				
//			case( TextAnchor.UpperCenter ):
//				position.x = (ScreenManager.ScreenWidth / 2) + position.x - (size.x / 2);
//				position.y = ScreenManager.ScreenHeight - position.y - size.y;
//				break;
//				
//			case( TextAnchor.UpperRight ):
//				position.x = position.x + size.x;
//				position.y = ScreenManager.ScreenHeight - position.y - size.y;
//				break;
//				
//			case( TextAnchor.MiddleLeft ):
//				position.y = (ScreenManager.ScreenHeight / 2) + position.y - (size.y / 2);
//				break;
//				
//			case( TextAnchor.MiddleCenter ):
//				position.x = (ScreenManager.ScreenWidth / 2) + position.x - (size.x / 2);
//				position.y = (ScreenManager.ScreenHeight / 2) + position.y - (size.y / 2);
//				break;
//				
//			case( TextAnchor.MiddleRight ):
//				position.x = position.x + size.x;
//				position.y = (ScreenManager.ScreenHeight / 2) + position.y - (size.y / 2);
//				break;
//				
//			case( TextAnchor.LowerLeft ):
//				break;
//				
//			case( TextAnchor.LowerCenter ):
//				position.x = (ScreenManager.ScreenWidth / 2) + position.x - (size.x / 2);
//				break;
//				
//			case( TextAnchor.LowerRight ):
//				position.x = position.x + size.x;
//				break;
//			}
			
			this.texture.pixelInset = new Rect( position.x, position.y, size.x, size.y );
		}

	} // ScaleableGuiTexture

} // WarOfTheThreeNations.Display.GUI

