using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DemoLVL");
        return;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
