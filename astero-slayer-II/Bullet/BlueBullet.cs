using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The boss' blue projectile's script. 
public class BlueBullet : MonoBehaviour
{
    private Rigidbody2D bulletBody;
    private Vector2 screenBounds;
    private float scrollSpeed = -8.0f;
    private int screenBound = -15;

    void Start()
    {
        bulletBody = this.GetComponent<Rigidbody2D>();
        bulletBody.velocity = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        if(transform.position.x < screenBound)
        {
            Destroy(this.gameObject);
        }
    }
}
