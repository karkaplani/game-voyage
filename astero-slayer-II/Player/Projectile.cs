using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is responsible for destroying the enemy objects in collision and generating either gem or health objects as well as explosion effect.
//It also keeps track of the enemy shot score.
public class Projectile : MonoBehaviour
{
    public float velocity = 10.0f;
    public Rigidbody2D beamBody;
    private Vector2 screenBounds;

    public GameObject gem;
    public GameObject explosion;
    public GameObject health;
    public AudioClip exploClip;

    void Start()
    {
        beamBody = this.GetComponent<Rigidbody2D>();
        beamBody.velocity = new Vector2(velocity, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(26, Screen.height-7, Camera.main.transform.position.z));
    }

    void Update()
    {
        if(transform.position.x > screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            AudioSource.PlayClipAtPoint(exploClip, transform.position); 
            Destroy(other.gameObject); Destroy(this.gameObject);

            GameObject g = Instantiate(gem) as GameObject;
            g.transform.position = other.transform.position;

            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = other.transform.position;
            Destroy(e, 0.5f);

        } else if(other.gameObject.tag == "Hostile" || other.gameObject.tag == "Kamikaze" || other.gameObject.tag == "BigHostile")
        {
            switch(other.gameObject.tag)
            {
                case "Hostile": Score.hostileShot++; break;
                case "Kamikaze": Score.kamikazeShot++; break;
                case "BigHostile": Score.bigShot++; break;        
            }
            AudioSource.PlayClipAtPoint(exploClip, transform.position); 
            Destroy(other.gameObject); Destroy(this.gameObject);

            GameObject h = Instantiate(health) as GameObject;
            h.transform.position = other.transform.position;

            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = other.transform.position;
            Destroy(e, 0.5f);

        } else if(other.gameObject.tag == "Boss")
        {
            AudioSource.PlayClipAtPoint(exploClip, transform.position); 
            Destroy(this.gameObject);

            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = new Vector2(other.transform.position.x-2, other.transform.position.y);
            Destroy(e, 0.5f);

            BossBehaviour.bossHealth--;
            GameObject bossHealthBar = GameObject.FindWithTag("BossHealthBar");
            bossHealthBar.transform.position = new Vector2(bossHealthBar.transform.position.x+0.05f,bossHealthBar.transform.position.y);
        }
    }
}
