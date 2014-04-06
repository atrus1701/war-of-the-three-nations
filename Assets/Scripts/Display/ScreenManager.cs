using UnityEngine;
using System.Collections.Generic;

namespace WarOfTheThreeNations.Display
{

	[ExecuteInEditMode]
	public class ScreenManager : MonoBehaviour
	{
	
		private static Vector2 gui_screen_size = new Vector2( 1920.0f, 1080.0f );
		private static bool update_every_frame = true;
		private static bool landscape_only = true;
	
		private static Camera current_camera;
		private static Camera background_camera;

		private static Vector2 last_screen_size;
		private static float last_screen_aspect_ratio;

		private static Rect camera_rect;
		private static float aspect_ratio;
		private static float scale;
	
	
		public void Start()
		{
			ScreenManager.last_screen_size = new Vector2();
			ScreenManager.last_screen_aspect_ratio = 0.0f;
			ScreenManager.aspect_ratio = ScreenManager.gui_screen_size.x / ScreenManager.gui_screen_size.y;
			ScreenManager.CalculateScreen();

			GameObject bc = GameObject.Find( "background-camera" );
			if( bc == null )
			{
				ScreenManager.background_camera = new GameObject( "background-camera", typeof(Camera) ).camera;
				ScreenManager.background_camera.depth = 0;
				ScreenManager.background_camera.clearFlags = CameraClearFlags.SolidColor;
				ScreenManager.background_camera.backgroundColor = Color.black;
				ScreenManager.background_camera.cullingMask = 0;
			}
			else
			{
				ScreenManager.background_camera = bc.camera;
			}
			
			EventManager.InvokeOnScreenChange();
		}
		
		public void Update()
		{
			if( !ScreenManager.update_every_frame ) return;
			
			bool screen_change = ScreenManager.CalculateScreen();
			if( !screen_change ) return;
			
			EventManager.InvokeOnScreenChange();
		}
	
		private static bool CalculateScreen()
		{
			float screen_aspect_ratio = 0.0f;
			if( Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.LandscapeLeft )
			{
				screen_aspect_ratio = (float)Screen.width / (float)Screen.height;
			}
			else
			{
				if( Screen.height  > Screen.width && ScreenManager.landscape_only )
					screen_aspect_ratio = (float)Screen.height / (float)Screen.width;
				else
					screen_aspect_ratio = (float)Screen.width / (float)Screen.height;
			}
			
			if( screen_aspect_ratio == ScreenManager.last_screen_aspect_ratio )
			{
				if( new Vector2( Screen.width, Screen.height ) != ScreenManager.last_screen_size )
				{
					ScreenManager.scale = ScreenManager.ScreenHeight / ScreenManager.gui_screen_size.y;
					return true;
				}
				return false;
			}
			ScreenManager.last_screen_aspect_ratio = screen_aspect_ratio;
			ScreenManager.last_screen_size = new Vector2( Screen.width, Screen.height );
	
			float inset = 0.0f;
			if( screen_aspect_ratio > ScreenManager.aspect_ratio )
			{
				inset = 1.0f - ( ScreenManager.aspect_ratio / screen_aspect_ratio );
				ScreenManager.camera_rect = new Rect( inset / 2.0f, 0.0f, 1.0f - inset, 1.0f );
			}
			else if( screen_aspect_ratio < ScreenManager.aspect_ratio )
			{
				inset = 1.0f - ( screen_aspect_ratio / ScreenManager.aspect_ratio );
				ScreenManager.camera_rect = new Rect( 0.0f, inset / 2.0f, 1.0f, 1.0f - inset );
			}
			else
			{
				ScreenManager.camera_rect = new Rect( 0.0f, 0.0f, 1.0f, 1.0f );
			}
			
			ScreenManager.scale = ScreenManager.ScreenHeight / ScreenManager.gui_screen_size.y;
			return true;
		}
	
		public static void ShowCamera( Camera camera )
		{
			if( ScreenManager.current_camera )
				ScreenManager.HideCamera( ScreenManager.current_camera );
			camera.depth = 1;
			ScreenManager.current_camera = camera;
		}
	
		public static void HideCamera( Camera camera )
		{
			camera.depth = -1;
		}
	
		public static void UpdateCamera( Camera camera )
		{
			camera.rect = ScreenManager.camera_rect;
		}
	
		public static int ScreenHeight
		{
			get { return (int)(ScreenManager.camera_rect.height * Screen.height); }
		}
	
		public static int ScreenWidth
		{
			get { return (int)(ScreenManager.camera_rect.width * Screen.width); }
		}
	
		public static int XOffset
		{
			get { return (int)(ScreenManager.camera_rect.x * Screen.width); }
		}
	
		public static int YOffset
		{
			get { return (int)(ScreenManager.camera_rect.y * Screen.height); }
		}
	
		public static Rect ScreenRect
		{
			get { return ScreenManager.camera_rect; }
		}
	
		public static Vector3 MousePosition
		{
			get
			{
				Vector2 mouse_position = Input.mousePosition;
				mouse_position.x -= ScreenManager.XOffset;
				mouse_position.y -= ScreenManager.YOffset;
				return mouse_position;
			}
		}
	
		public static Vector2 GuiMousePosition
		{
			get
			{
				Vector2 mouse_position = Event.current.mousePosition;
				mouse_position.x = Mathf.Clamp( mouse_position.x, ScreenManager.XOffset, ScreenManager.XOffset + ScreenManager.ScreenWidth );
				mouse_position.y = Mathf.Clamp( mouse_position.y, ScreenManager.YOffset, ScreenManager.YOffset + ScreenManager.ScreenHeight );
				return mouse_position;
			}
		}
		
		public static Vector2 GuiGetAdjustedPosition( Vector2 position )
		{
			return position * ScreenManager.scale;
		}
		
		public static Vector2 GuiGetAdjustSize( Vector2 size )
		{
			return size * ScreenManager.scale;
		}
	
		public static float ScaleValue( float value )
		{
			return value * ScreenManager.scale;
		}
		
		
		public void ScaleGuiTexture( GUITexture texture, 
	}

}

