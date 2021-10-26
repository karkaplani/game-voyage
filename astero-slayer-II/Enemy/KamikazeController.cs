using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeController : MonoBehaviour
{
    private Rigidbody2D kamikazeBody;
    public float scrollSpeed = -30.0f;

    void Start()
    {
        kamikazeBody = GetComponent<Rigidbody2D>();
        kamikazeBody.velocity = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        if(transform.position.x < -15) 
        {
            Destroy(this.gameObject);
        }
    }
}
