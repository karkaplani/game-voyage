using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileController : MonoBehaviour
{
    private Rigidbody2D hostileBody;
    private float scrollSpeed = -3.0f;
    private int screenBound = -15;

    public GameObject bullet;
    public GameObject bullet2; 
    public GameObject bullet3;

    private float shootTime = 2.0f;

    void Start()
    {
        hostileBody = GetComponent<Rigidbody2D>();
        hostileBody.velocity = new Vector2(scrollSpeed, 0);
        StartCoroutine(ShootTimer());
    }

    void Update()
    {
        if(transform.position.x < screenBound) 
        {
            Destroy(this.gameObject);
        }
    }

    public void ShootBullet()
    {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = hostileBody.transform.position;

        GameObject b2 = Instantiate(bullet2) as GameObject;
        b2.transform.position = hostileBody.transform.position;

        GameObject b3 = Instantiate(bullet3) as GameObject;
        b3.transform.position = hostileBody.transform.position; 
    }

    IEnumerator ShootTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootTime);
            ShootBullet();
        }
    }
}
