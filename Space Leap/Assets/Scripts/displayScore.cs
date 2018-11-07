using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayScore : MonoBehaviour {
    public Texture2D[] numbers;
    public int currentScore=0;

    public static int score;

    public  int highscore;
    public Transform player;
    public int numOfLazersHopped;
    public float yDistanceBetweenLaser;
    public float yStartLaser;
    public int offset = 20;
    TextMesh text;
    public float ypos;
    public bool isHighScore = false;
    public float hideOffset = 3000;
    void Start()
    {
        text = GetComponent<TextMesh>();
        numOfLazersHopped = 0;
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    void Update()
    {
        hideOffset = this.transform.position.x;
        currentScore = numOfLazersHopped -1;
        if (player.transform.position.y > (numOfLazersHopped * yDistanceBetweenLaser) + yStartLaser)
        {
            numOfLazersHopped++;
        }
        if (currentScore > highscore)
        {
            highscore = currentScore;
            PlayerPrefs.SetInt("highscore", highscore);
        }

        if (isHighScore)
        {
            if (highscore < 10)
            {
                offset = 0;
            }
            else if (highscore >= 10 && highscore < 100)
            {
                offset = 100;

            }
            else
            {
                offset = 200;

            }
        }
        else
        {
            if (currentScore < 10)
            {
                offset = 0;
            }
            else if (currentScore >= 10 && currentScore < 100)
            {
                offset = 45;

            }
            else
            {
                offset = 90;

            }
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
        if (currentScore > highscore)
        {
            highscore = currentScore;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        if (isHighScore)
        {
            int numOfDigits = highscore.ToString().Length;
            for (int i = 0; i < numOfDigits; i++)
            {
                int a;
                if (i == 0)
                {
                    a = (highscore / (int)Mathf.Pow(10, numOfDigits - 1));


                }
                else
                {
                    a = (highscore % (int)Mathf.Pow(10, numOfDigits - i) / (int)Mathf.Pow(10, numOfDigits - i - 1));
                }
                if (a < numbers.Length - 1 && a >= 0)
                {
                    GUI.DrawTexture(new Rect(i * ((Screen.width / 10)) + (Screen.width / 2) + (Screen.width / 12) + hideOffset, (Screen.height / 4), (Screen.width / 10), (Screen.width / 10)), numbers[a]);
                }
            }

        }
        else
        {
            int numOfDigits = currentScore.ToString().Length;
            for (int i = 0; i < numOfDigits; i++)
            {
                int a;
                if (i == 0)
                {
                    a = (currentScore / (int)Mathf.Pow(10, numOfDigits - 1));


                }
                else
                {
                    a = (currentScore % (int)Mathf.Pow(10, numOfDigits - i) / (int)Mathf.Pow(10, numOfDigits - i - 1));
                }
                if (a < numbers.Length - 1 && a >= 0)
                {
                    GUI.DrawTexture(new Rect(i * ((Screen.width / 11)) + (Screen.width / 2)+(Screen.width / 12), (Screen.height / 16), (Screen.width / 12), (Screen.width / 12)), numbers[a]);
                }
            }
        }
    }
}
