using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {
    public static int score;

    public static int highscore;
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
        if (player.transform.position.y > (numOfLazersHopped * yDistanceBetweenLaser) + yStartLaser)
        {
            numOfLazersHopped++;
        }


        text.text = "" + numOfLazersHopped + " highscore:" + highscore;


        if (numOfLazersHopped > highscore)
        {
            highscore = numOfLazersHopped;
            text.text = "" + numOfLazersHopped;

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
}