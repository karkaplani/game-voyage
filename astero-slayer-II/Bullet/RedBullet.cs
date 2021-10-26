using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This projectile moves towards the player.
public class RedBullet : MonoBehaviour
{
    private Vector2 shipPosition;
    private Vector2 destination;
    private Vector2 bulletPosition;

    private float speed = 8.0f;
    private int destructionPoint = -10;

    public GameObject ship;

    void Start()
    {
        ship = GameObject.FindWithTag("Ship");
        shipPosition = ship.transform.position;
        bulletPosition = this.transform.position;
        destination = new Vector2(shipPosition.x-6.0f, shipPosition.y);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination, step);
        if(transform.position.x < destructionPoint)
        {
            Destroy(this.gameObject);
        }
    }
}
