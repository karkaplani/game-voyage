using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shield appears at the same position as the ship.
public class Shield : MonoBehaviour
{
    Rigidbody2D shieldBody;
    GameObject ship;

    void Start()
    {
        ship = GameObject.FindWithTag("Ship");
        shieldBody = GetComponent<Rigidbody2D>();
        transform.position = ship.transform.position;
    }

    void Update()
    {
        transform.position = ship.transform.position;
    }
}
