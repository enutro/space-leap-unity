﻿using UnityEngine;
using System.Collections;

public class FollowUFO : MonoBehaviour
{

    public GameObject ufo;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = new Vector3(ufo.transform.position.x, transform.position.y, 0);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (Timer.gameRunning) {
            offset = new Vector3(ufo.transform.position.x, transform.position.y, 0);

            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = offset;
        }
    }
}