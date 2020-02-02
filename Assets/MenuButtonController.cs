using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
      Application.Quit();
    }

    public void Continue()
    {
      
    }
}
