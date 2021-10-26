using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The difference from the ShipController script is that there is a shield mechanic for that level. 
//Health does not decrease while shield is open.
public class ShipControllerBoss : MonoBehaviour
{
    private Rigidbody2D shipBody;
    public float upForce = 200; 
    public GameObject projectile;
    
    AudioSource audioSource;
    public AudioClip shootClip;

    public GameObject healthBar;
    public static int health;

    public GameObject energyBar;
    private int energy;

    public GameObject explosion;

    public AudioClip healthUpSound;
    public GameObject shield;

    void Start()
    {
        shipBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        health = 10;
        energy = 10;
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            shipBody.velocity = Vector2.zero;
            shipBody.AddForce(new Vector2(0,upForce));
        }

        if(Input.GetKeyDown("z"))
        { 
            if(energy > 0)
            {
                Shoot();
                this.ReduceEnergy();
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Hostile" || other.gameObject.tag == "Bullet" ||
           other.gameObject.tag == "Bullet2" || other.gameObject.tag == "Bullet3" || other.gameObject.tag == "Kamikaze" ) && shield.activeSelf == false)
        {
            this.ReduceHealth();
            Destroy(other.gameObject);
            GameObject e = Instantiate(explosion) as GameObject;
            Destroy(e, 0.5f);

            e.transform.position = this.transform.position;
            if(health == 0)
            {
                //GameControl.instance.ShipDestroyed();
                //Destroy(this.gameObject);
            }
        } else if(other.gameObject.tag == "Health")
        {
            if(health < 10)
            {
                this.PlaySound(healthUpSound);
                Destroy(other.gameObject);
                IncreaseHealth();
            }
        } else if(other.gameObject.tag == "RadicalBeam" && shield.activeSelf == false)
        {
            this.ReduceHealth();
            GameObject e = Instantiate(explosion) as GameObject;
            Destroy(e, 0.5f);
            e.transform.position = this.transform.position;
        }
    }

    public void Shoot()
    {
        GameObject p = Instantiate(projectile) as GameObject;
        p.transform.position =  shipBody.transform.position;
        this.PlaySound(shootClip);
        StartCoroutine(IncreaseEnergy());
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void ReduceHealth()
    {
        health--;
        healthBar.transform.position = new Vector2(healthBar.transform.position.x-0.2f,healthBar.transform.position.y);
    }

    public void IncreaseHealth()
    {
        health++;
        healthBar.transform.position = new Vector2(healthBar.transform.position.x+0.2f,healthBar.transform.position.y);
    }

    public void ReduceEnergy()
    {
        energy--;
        energyBar.transform.position = new Vector2(energyBar.transform.position.x-0.2f,energyBar.transform.position.y);
    }

    IEnumerator IncreaseEnergy()
    {
        yield return new WaitForSeconds(5.0f);
        energy++;
        energyBar.transform.position = new Vector2(energyBar.transform.position.x+0.2f,energyBar.transform.position.y);
    }
}

