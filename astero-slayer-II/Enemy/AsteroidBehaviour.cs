using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to define an asteroid's movement.

public class AsteroidBehaviour : MonoBehaviour
{
    private Rigidbody2D asteroBody;
    private float rotVelocity = 0.07f;

    void Start()
    {
        asteroBody = GetComponent<Rigidbody2D>();
        asteroBody.velocity = new Vector2(Random.Range(-5.0f, -2.0f), 0);   
    }

    void Update()
    {
        transform.Rotate(0,0,rotVelocity);
        if(transform.position.x < -15) 
        {
            Destroy(this.gameObject);
        }
    }
}
