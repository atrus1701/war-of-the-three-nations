using UnityEngine;
using System.Collections.Generic;

namespace WarOfTheThreeNations.Display
{
	
	[RequireComponent(typeof (Camera))]
	[ExecuteInEditMode]
	public class RegisteredCamera : MonoBehaviour
	{
		
		public void Start()
		{
			EventManager.OnScreenChange += this.UpdateCamera;
			//ScreenManager.HideCamera( transform.camera );
			//ScreenManager.ShowCamera( transform.camera );
		}
		
		private void UpdateCamera()
		{
			ScreenManager.UpdateCamera( transform.camera );
		}

	}

}

