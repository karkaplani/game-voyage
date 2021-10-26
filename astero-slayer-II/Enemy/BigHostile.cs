using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHostile : MonoBehaviour
{
    private Rigidbody2D bigBody;
    private float scrollSpeed = -3.0f;
    public GameObject bullet;
    private int timer; 
    private int shootTime = 2; //Fire a new bullet every 2 sec

    void Start()
    {
        bigBody = GetComponent<Rigidbody2D>();
        bigBody.velocity = new Vector2(scrollSpeed, 0);
        StartCoroutine(BigHostileStopper());
        StartCoroutine(ShootTimer());
    }

    IEnumerator BigHostileStopper() //In order to stop the hostile at the certain point 
    {
        while(timer <= 100)
        {
            yield return new WaitForSeconds(5);
            timer++;
            StopBig();
        }
    }

    public void StopBig()
    {
        bigBody.velocity = new Vector2(0,0);
    }

    IEnumerator ShootTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootTime);
            ShootBullet();
        }
    }

    public void ShootBullet()
    {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = bigBody.transform.position;
    }
}
