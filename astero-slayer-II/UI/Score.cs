using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int gems = 0;
    public static int hostileShot = 0;
    public static int kamikazeShot = 0;
    public static int bigShot = 0;
    public static int scoreTotal;

    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreTotal = (gems*5) + (hostileShot * 10) + (bigShot * 15) + (kamikazeShot * 20);
        switch(this.gameObject.tag)
        {
            case "Gemtext":
                scoreText.text = "x" + gems;
                break;
            case "Hostext":
                scoreText.text = "x" + hostileShot;
                break;
            case "Kamitext":
                scoreText.text = "x" + kamikazeShot;
                break;
            case "Bigtext":
                scoreText.text = "x" + bigShot;
                break;
            case "Scoretext":
                scoreText.text = "SCORE:\n" + scoreTotal;
                break;    
        }
    }
}
