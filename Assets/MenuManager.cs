using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playGame(string NinjaFrog)
    {
        SceneManager.LoadScene(NinjaFrog);
    }

    public void Credits(string Credits)
    {
        SceneManager.LoadScene(Credits);
    }

    public void MainMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
