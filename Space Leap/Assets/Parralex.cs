using UnityEngine;
using System.Collections;

public class Parralex : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object

    public float playerHeight;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public float foreGroundSpeedToBackgroundSpeedRatio =20;
    // Use this for initialization
    void Start()
    {    playerHeight = 0;

    //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    }

    void Update()
    {

        if (player.transform.position.y < 0.47)
        {
            offset = new Vector3(0, 5.675f , 0);

        }
        else
        {
            offset = new Vector3(0, (5.675f+ (player.transform.position.y- 0.47f) / 1.2f) , 0);
        }
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = offset;
    }
}