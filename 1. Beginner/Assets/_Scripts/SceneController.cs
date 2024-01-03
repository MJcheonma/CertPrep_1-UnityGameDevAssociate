using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LOADSCENE()
    {
        SceneManager.LoadScene("Game");
    }

    public void MAINMENU()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void EXIT_BTN()
    {
        Application.Quit();
    }
}
