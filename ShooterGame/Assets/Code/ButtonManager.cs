using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour {

    public void OpenScene(string sceneName)
    {
        //TODO : DO Some Effect for loading the scene
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        //TODO: Play Some Music
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
  /*   void Update()
    {
        if (Input.GetButtonDown("QuitGame"))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Player1Attack01"))
        {
            OpenScene("GameScene01");
        }
    }
    */

}
