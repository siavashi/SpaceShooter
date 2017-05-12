using UnityEngine;

namespace TAMKShooter.GUI
{
	public class GlobalGUI : MonoBehaviour
	{
		private LoadingIndicator _loader;

		private static GlobalGUI _current;

		protected void Awake()
		{
			if ( _current == null )
			{
				_current = this;
				Debug.Log( "GlobalGUI Awake" );
				DontDestroyOnLoad( gameObject );

				_loader = GetComponentInChildren< LoadingIndicator >( true );
				_loader.Init();
			}
			else
			{
				Destroy( gameObject );
			}
		}
	}
}
