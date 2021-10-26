using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldCount : MonoBehaviour
{
    public static int shields = 3;
    Text shieldText;

    void Start()
    {
        shieldText = GetComponent<Text>();
    }

    void Update()
    {
        shieldText.text = "X" + shields;        
    }
}
