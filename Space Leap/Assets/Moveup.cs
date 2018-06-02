using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveup : MonoBehaviour
{



    public float speed;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public float foreGroundSpeedToBackgroundSpeedRatio = 20;
    // Use this for initialization
    void Start()
    {
        speed = 0.01f;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    }

    void Update()
    {

     if (speed < 0.05)
        {
            speed = speed + 0.00005f;
        }
            offset = new Vector3(0, transform.position.y + speed, 0);

        
      
        transform.position = offset;
    }
}