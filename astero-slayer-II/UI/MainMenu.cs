using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject instructions;
    public GameObject pauseMenu;
    public GameObject gameMode;

    public void Play()
    {
        menu.SetActive(false);
        gameMode.SetActive(true);
    }

    public void Instructions() 
    {
        menu.SetActive(false);
        instructions.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        instructions.SetActive(false);
        menu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Score.gems = 0;
        Score.hostileShot = 0;
        Score.kamikazeShot = 0;
        Score.bigShot = 0;
        ShieldCount.shields = 3;
    }

    public void HuntMode()
    {
        SceneManager.LoadScene(7);
    }

    public void NormalMode()
    {
        SceneManager.LoadScene(1);
    }
}
