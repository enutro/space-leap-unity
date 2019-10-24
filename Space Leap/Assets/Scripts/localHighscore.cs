using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class localHighscore : MonoBehaviour
{

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