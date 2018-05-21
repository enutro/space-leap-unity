using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    bool jumpSuccess;


    public static float xDistanceBetweenEachLaser= 2.5f;
    public  float leftLaserXPosition ;
    public float rightLaserXPosition;
    public  float leftLaserYPosition;

    // player main camera tag as Player
    public Transform player;
    // mutiple laser objects
    public Transform leftlaser;
    public Transform rightlaser;

    // Minimum and Maximum number of lasers
    private float playerY;
    private float playerX;
    private float startX;
    public float numOfLazersHopped =0;
    private float distanceBetweenEachLaser =0.890f;
    bool currentLaserLeft;
    bool nextLaserLeft;
    int randomLaserNumber;
    int xLaser;

    void Start()
    {
        randomLaserNumber = Random.Range(0, 2);
        leftLaserXPosition = -0.235f;
        rightLaserXPosition = 0.235f;
        if (randomLaserNumber==0)
        {
            Object.Instantiate(leftlaser, new Vector3(leftLaserXPosition, numOfLazersHopped * distanceBetweenEachLaser  - 0.195f), transform.rotation);

        }
        else
        {
            Object.Instantiate(rightlaser, new Vector3(rightLaserXPosition, numOfLazersHopped * distanceBetweenEachLaser - 0.195f, 0), transform.rotation);

        }

    }

    void Update()
    {
        
        // used to find the Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerY = player.transform.position.y;
        playerX = player.transform.position.x;


        // get the distance between the player and the laser GameObject
        float dist = Vector3.Distance(player.transform.position, this.transform.position);



        if (player.transform.position.y > (numOfLazersHopped* distanceBetweenEachLaser) - 0.195f)
        {
            numOfLazersHopped++;
            randomLaserNumber = Random.Range(0, 2);


            if (randomLaserNumber == 0)
            {
                Object.Instantiate(leftlaser, new Vector3(leftLaserXPosition, numOfLazersHopped * distanceBetweenEachLaser - 0.195f), transform.rotation);

            }
            else
            {
                Object.Instantiate(rightlaser, new Vector3(rightLaserXPosition, numOfLazersHopped * distanceBetweenEachLaser - 0.195f, 0), transform.rotation);

            }
        }




      


    }
}