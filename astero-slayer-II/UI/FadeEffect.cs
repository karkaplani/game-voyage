using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is made to achieve the fade effect at first, but it also changes the level.
public class FadeEffect : MonoBehaviour
{
    public Animator animator;
    private int timeToWait;
    private int levelToLoad;
    private string currentLevel;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentLevel = currentScene.name;
        switch(currentLevel) 
        {
            case "Level1":
                 StartCoroutine(LevelStarter(130,2)); break;
            case "Level2":
                StartCoroutine(LevelStarter(190,3)); break; 
            case "Level3":
                StartCoroutine(LevelStarter(310,4)); break; 
            case "PowerupScene":
                StartCoroutine(LevelStarter(6,5));  break;        
        }
    }

    void Update()
    {
        if(currentLevel == "BossFight" && BossBehaviour.bossHealth <= 0)
        {
            FadeToLevel(6);
        }
    }

    IEnumerator LevelStarter(int waitingTime, int sceneToLoad)
    {
        yield return new WaitForSeconds(waitingTime);
        FadeToLevel(sceneToLoad);
    }

    public void FadeToLevel(int sceneToLoad)
    {
        levelToLoad = sceneToLoad;  
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
