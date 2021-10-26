using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D bgBody;
    public float scrollSpeed = -1.5f;

    void Start()
    {
        bgBody = GetComponent<Rigidbody2D>();
        bgBody.velocity = new Vector2(scrollSpeed, 0);
    }
}
