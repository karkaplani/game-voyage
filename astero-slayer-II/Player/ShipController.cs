using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main player script. Gravity is applied to the object and it goes up whenever the spacebar is pressed.
//Also a projectile is spawned on pressing Z, as long as there is energy. 
//Energy is reduced when a projectile is spawned, and loads again after some time.
//Health is reduced on collision with another enemy object and increased if a health object is collected.
//When the health is 0, the object is destroyed by calling the ShipDestroyed function of GameControl script.
public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipBody;
    public GameObject projectile;
    public float upForce = 200; 
    
    AudioSource audioSource;
    public AudioClip shootClip;

    public GameObject healthBar;
    public static int health;

    public GameObject energyBar;
    private int energy;

    public GameObject explosion;

    public AudioClip healthUpSound;

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
        if(other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Hostile" || other.gameObject.tag == "Bullet" ||
           other.gameObject.tag == "Bullet2" || other.gameObject.tag == "Bullet3" || other.gameObject.tag == "Kamikaze" )
        {
            this.ReduceHealth();
            Destroy(other.gameObject);
            GameObject e = Instantiate(explosion) as GameObject; 
            e.transform.position = this.transform.position; Destroy(e, 0.5f);
            if(health == 0)
            {
                GameControl.instance.ShipDestroyed();
                Destroy(this.gameObject);
            }
        } else if(other.gameObject.tag == "Health")
        {
            if(health < 10) //Prevents health from going above 10
            {
                this.PlaySound(healthUpSound);
                Destroy(other.gameObject);
                IncreaseHealth();
            }
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
