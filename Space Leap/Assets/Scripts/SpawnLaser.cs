using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    bool jumpSuccess;


    public  float yStartLaser;
    public  float yDistanceBetweenLaser;
    public float xRightLaser;
    public float xLeftLaser;
    public int numOfLazersHopped = 0;



    // player main camera tag as Player
    public Transform player;
    // mutiple laser objects
    public Transform leftLaser;
    public Transform rightLaser;

    int randomLaserNumber;
   

    void Start()
    {
        randomLaserNumber = Random.Range(0, 2);
        if (randomLaserNumber==0)
        {
            Object.Instantiate(leftLaser, new Vector3(xLeftLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

        }
        else
        {
            Object.Instantiate(rightLaser, new Vector3(xRightLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

        }

    }

    void Update()
    {
        

        if (player.transform.position.y > (numOfLazersHopped* yDistanceBetweenLaser) + yStartLaser)
        {
            numOfLazersHopped++;
            randomLaserNumber = Random.Range(0, 2);

            randomLaserNumber = Random.Range(0, 2);
            if (randomLaserNumber == 0)
            {
                Object.Instantiate(leftLaser, new Vector3(xLeftLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

            }
            else
            {
                Object.Instantiate(rightLaser, new Vector3(xRightLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

            }
        }




      


    }
}