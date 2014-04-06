using UnityEngine;
using System.Collections.Generic;


namespace WarOfTheThreeNations.Display
{

	public class Minimap : MonoBehaviour
	{
	
		public struct MinimapLocation
		{
			public string name;
			public Vector2 position;
			public Color color;
		}
	
		public Camera camera;
		public GameObject map_plane;
		public Texture map;
		public Vector2 map_size = new Vector2();

		private GUITexture gui;
		public Texture gui_frame;
		public Rect gui_position = new Rect();

		private Vector2 character_location = new Vector2();
		
		public List<MinimapLocation> locations = new List<MinimapLocation>();
	
		public void Start()
		{
			this.map_plane = transform.FindChild( "minimap-plane" );
			this.camera = transform.FindChild( "minimap-camera" ) as Camera;
			this.gui = tranform.FindChild( "minimap-frame" ) as GUITexture;

			if( this.map_plane == null )
				this.map_plane = Instantiate( GameObject.CreatePrimitive(PrimitiveType.Quad) );

			if( this.camera )
				this.camera = Instantiate( new Camera() ) as Camera;
				
			if( this.gui )
				this.gui = Instantiate( new GUITexture() ) as GUITexture;
						
			// setup map
			
			this.map_plane.guiTexture.texture = this.map;
			this.map_plane.transform.position = new Vector3( this.map_size.x / 2, -950, this.map_size.y );
			this.map_plane.transform.localRotation = new Vector3( 90, 0, 0 );
			this.map_plane.transform.localScale = new Vector3( this.map_size.x, this.map_size.y, 0 );

			// setup camera
			this.camera.clearFlags = CameraClearFlags.Depth;
			this.camera.orthographic = true;
			this.camera.orthographicSize = 300;
			this.camera.nearClipPlane = 0;
			this.camera.farClipPlane = 100;
			this.camera.depth = 100;
			this.camera.renderingPath = RenderingPath.Forward;
			this.camera.useOcclusionCulling = false;
			this.camera.hdr = false;
			// scaled viewport
			
				
			// setup gui
			
			
			
		}
		
		public void LateUpdate()
		{
			
		}
		
		public Vector2 CharacterLocation
		{
			set { this.character_location = value; }
		}
	
	} // Minimap

} // WarOfTheThreeNations.Display

