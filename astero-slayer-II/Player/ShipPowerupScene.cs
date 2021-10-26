using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only for animation purpose
public class ShipPowerupScene : MonoBehaviour
{
    Rigidbody2D shipBody;
    float scrollSpeed = 2.0f;
    void Start()
    {
        shipBody = GetComponent<Rigidbody2D>();
        shipBody.velocity = new Vector2(scrollSpeed, 0);
    }
}
