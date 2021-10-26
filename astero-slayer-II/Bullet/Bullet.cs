using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hostile's projectile script. Three of them are fired going to different directions.
public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletBody;
    private int screenBound = -15;

    private float xSpeed = -4.0f;
    private float ySpeed = 3.0f;
    private float negativeYSpeed = -3.0f; //For the third projectile

    void Start()
    {
        bulletBody = this.GetComponent<Rigidbody2D>();

        if(this.tag == "Bullet") 
        {
            bulletBody.velocity = new Vector2(xSpeed, 0); //Going horizontally with 4v
        } else if(this.tag == "Bullet2")
        {
            bulletBody.velocity = new Vector2(xSpeed, ySpeed); //Going up-diagonally with 5v 
        } else if(this.tag == "Bullet3")
        {
            bulletBody.velocity = new Vector2(xSpeed, negativeYSpeed); //Going down-diagonally with 5v
        }
    }

    void Update()
    {
        if(transform.position.x < screenBound)
        {
            Destroy(this.gameObject);
        }
    }
}
