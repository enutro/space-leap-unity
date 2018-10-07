using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayScore : MonoBehaviour {
    public Texture2D[] numbers;
    public int currentScore=123;

    public static int score;

    public  int highscore;
    public Transform player;
    public int numOfLazersHopped;
    public float yDistanceBetweenLaser;
    public float yStartLaser;

    TextMesh text;

    void Start()
    {
        text = GetComponent<TextMesh>();
        numOfLazersHopped = 0;
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    void Update()
    {
        currentScore = numOfLazersHopped -1;
        if (player.transform.position.y > (numOfLazersHopped * yDistanceBetweenLaser) + yStartLaser)
        {
            numOfLazersHopped++;
        }
        if (numOfLazersHopped > highscore)
        {
            highscore = numOfLazersHopped;

            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
    // Update is called once per frame
    void OnGUI() {
        int numOfDigits = currentScore.ToString().Length;
        for (int i= 0;i< numOfDigits; i++)
        {
            int a;
            if (i == 0)
            {
              a = (currentScore / (int)Mathf.Pow(10, numOfDigits-1));


            }
            else
            {
                a = (currentScore % (int)Mathf.Pow(10, numOfDigits- i) / (int)Mathf.Pow(10, numOfDigits-i-1));
            }
            GUI.DrawTexture(new Rect(i*100+(490), 100, 100, 100), numbers[a]);
        }
    }
}
