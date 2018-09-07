using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTower : MonoBehaviour
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
    
            if ( transform.position.y < 1.1f)
            {
                speed = speed + 0.0015f;
                offset = new Vector3(0, transform.position.y + speed, 0);

        }
        else if (transform.position.y < 2.4f)
        {
            speed = speed + 0.002f;
            offset = new Vector3(0, transform.position.y + speed, 0);
        }
        else if (transform.position.y < 3.4f)
        {
            speed = speed + 0.025f;
            offset = new Vector3(0, transform.position.y + speed, 0);
        }
        else if (transform.position.y < 22.4f)
        {
            speed = speed + 0.03f;
            offset = new Vector3(0, transform.position.y + speed, 0);
        }
            else
            {
                speed = 0;
                offset = new Vector3(0, 22.4f, 0);

            }

            transform.position = offset;
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

      
    }
}