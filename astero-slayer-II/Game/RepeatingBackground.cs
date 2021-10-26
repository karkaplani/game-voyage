using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script creates a continious background effect by replacing two identical background images interchangeably.
public class RepeatingBackground : MonoBehaviour
{
    private float groundLength;

    void Awake()
    {
        groundLength = 26;
    }

    void Update()
    {
        if(transform.position.x < -groundLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundLength * 2f, 0);
        transform.position = (Vector2) transform.position + groundOffset;
    }
}
