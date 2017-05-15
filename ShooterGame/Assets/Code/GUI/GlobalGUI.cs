using UnityEngine;
using SM = UnityEngine.SceneManagement;

namespace TAMKShooter.GUI
{
	public class GlobalGUI : MonoBehaviour
	{
        private LoadingIndicator _loader;
        private WinGameIndicator _winGameText;

        private static GlobalGUI _current;

		protected void Awake()
		{
			if ( _current == null )
			{
				_current = this;
				Debug.Log( "GlobalGUI Awake" );
				DontDestroyOnLoad( gameObject );
                
                _loader = GetComponentInChildren< LoadingIndicator >( true );
                _winGameText = GetComponentInChildren<WinGameIndicator>(true);

                _loader.Init();

                Debug.Log("SM.SceneManager.GetActiveScene().name: " + SM.SceneManager.GetActiveScene().name);
                if (SM.SceneManager.GetActiveScene().name == "Level1")
                {
                    Debug.Log("WINWINWIN");
                    _winGameText.Init();
                }
            }
			else
			{
				Destroy( gameObject );
			}
		}
	}
}
