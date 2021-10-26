using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Boss script, to make the boss fire projectiles as well as give it an entrance effect to the boss.
public class BossBehaviour : MonoBehaviour
{
    private Rigidbody2D bossBody;
    private float scrollSpeed = -3.0f;
    private int timer;

    public GameObject blueBeam; int blueTimer = 4;
    public GameObject redBeam; int redTimer = 3;
    public GameObject radicalBeam; int radicalTimer = 8;

    public GameObject bossHealthBar;
    public static int bossHealth;

    public GameObject explosion;
    public AudioClip exploClip;

    AudioSource audioSource;

    void Start()
    {
        bossHealth = 100;
        bossBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        bossBody.velocity = new Vector2(scrollSpeed, 0);
        timer = 0;
        StartCoroutine(BossStopper());
        StartCoroutine(ProjectileTimer(blueTimer, "Blue"));
        StartCoroutine(ProjectileTimer(redTimer, "Red"));
        StartCoroutine(ProjectileTimer(radicalTimer, "Radical"));
    }

    void Update()
    {
        if(bossHealth <= 0)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            AudioSource.PlayClipAtPoint(exploClip, transform.position); 
            Destroy(this.gameObject);
        }
    }

    IEnumerator BossStopper()
    {
        while(timer <= 100)
        {
            yield return new WaitForSeconds(3);
            timer++;
            StopBoss();
        }
    }

    IEnumerator ProjectileTimer(int waitTime, string projectileName)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            switch(projectileName) 
            {
                case "Blue": FireBlueBullet(); break;
                case "Red": FireRedBullet(); break;
                case "Radical": FireRadicalBeam(); break;
            }
        }
    }

    public void StopBoss()
    {
        bossBody.velocity = new Vector2(0,0);
    }

    public void FireRadicalBeam()
    {
        GameObject r = Instantiate(radicalBeam) as GameObject;

        r.transform.position = bossBody.transform.position;
    }

    public void FireRedBullet()
    {
        GameObject red = Instantiate(redBeam) as GameObject;
        GameObject red2 = Instantiate(redBeam) as GameObject;
        GameObject red3 = Instantiate(redBeam) as GameObject;

        red.transform.position = new Vector2(transform.position.x, transform.position.y);
        red2.transform.position = new Vector2(transform.position.x-1, transform.position.y);
        red3.transform.position = new Vector2(transform.position.x-0.5f, transform.position.y+1);
    }

    public void FireBlueBullet()
    {
        GameObject blue = Instantiate(blueBeam) as GameObject;
        GameObject blue2 = Instantiate(blueBeam) as GameObject;
        GameObject blue3 = Instantiate(blueBeam) as GameObject;
        GameObject blue4 = Instantiate(blueBeam) as GameObject;

        blue.transform.position = new Vector2(transform.position.x, transform.position.y+1);
        blue2.transform.position = new Vector2(transform.position.x+1, transform.position.y+1);
        blue3.transform.position = new Vector2(transform.position.x, transform.position.y-2);
        blue4.transform.position = new Vector2(transform.position.x-1, transform.position.y-2);
    }
}
