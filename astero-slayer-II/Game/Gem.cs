using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public Rigidbody2D gemBody;
    private int screenBound = -15;
    public ShipController s;
    public float speed = -2.5f;

    public AudioClip collectSound;
    public int score;
    public Text scoreText;

    void Start()
    {
        gemBody = this.GetComponent<Rigidbody2D>();
        gemBody.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        if(transform.position.x < screenBound)
        {
            Destroy(this.gameObject);
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ship")
        {   
            if(this.tag == "Gem")
            {
                Score.gems += 1;  
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
                Destroy(this.gameObject);
            }
        }
    }  
}
