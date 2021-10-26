using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Every level, one more enemy type is being spawned regularly addition to the previous type.
public class HostileMaker : MonoBehaviour
{
    public GameObject hostilePrefab;
    public GameObject kamikazePrefab;
    public GameObject bigHostilePrefab;

    public float respawnTime = 8.0f;
    public float longRespawnTime = 12.0f;
    public float longestRespawnTime = 30.0f;

    private Vector2 screenBounds;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(26, Screen.height, Camera.main.transform.position.z));

        if(sceneName == "Level1")
        {
            StartCoroutine(HostileWave());
        }else if(sceneName == "Level2")
        {
            StartCoroutine(HostileWave());
            StartCoroutine(KamikazeWave());
        }else if(sceneName == "Level3") 
        {
            StartCoroutine(HostileWave());
            StartCoroutine(KamikazeWave());
            StartCoroutine(BigHostileWave());
        }
    }

    public void SpawnHostile()
    {
        GameObject a = Instantiate(hostilePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    public void SpawnKamikaze()
    {
        GameObject k = Instantiate(kamikazePrefab) as GameObject;
        k.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }    

    public void SpawnBigHostile()
    {
        GameObject b = Instantiate(bigHostilePrefab) as GameObject;
        b.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator HostileWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnHostile();
        }
    }

    IEnumerator KamikazeWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(longRespawnTime);
            SpawnKamikaze();
        }
    }

    IEnumerator BigHostileWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(longestRespawnTime);
            SpawnBigHostile();
        }
    }
}
