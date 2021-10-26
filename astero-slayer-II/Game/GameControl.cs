using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This script controls the pause menu and game over UI components as well as the shield object at the boss fight.
public class GameControl : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject pauseMenu;
    public GameObject shield;

    public bool gameOver = false;
    public static GameControl instance;

    void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else if(instance != this) 
        {
            Destroy(gameOverText);
        }
    }

    void Update()
    {
        if(gameOver == true && Input.GetKeyDown("space")) //After lost and space is pressed, the level is loaded again with reset gems.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Score.gems = 0;
            ShieldCount.shields = 3;
        }

        if(Input.GetKeyDown("escape"))
        {
            pauseMenu.SetActive(true);
        }

        if(Input.GetKeyDown("x") && ShieldCount.shields > 0 && shield.activeSelf == false)
        {
            shield.SetActive(true);
            ShieldCount.shields--;
            StartCoroutine(ShieldTimer());
        }

        if(Input.GetKeyDown("t")) {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }

    public void ShipDestroyed()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    IEnumerator ShieldTimer() 
    {
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
    }
}
