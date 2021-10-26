using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Every 2 seconds, a new asteroid is spawned within the screen's y bounds.
public class AsteroidMaker : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 2.0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(26, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    public void SpawnAsteroid()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator AsteroidWave()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            SpawnAsteroid();
        }
    }
}
