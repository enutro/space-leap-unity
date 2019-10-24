using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class followXplayer : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public bool chasing = true;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public bool moveHasBeenMade = false;

    void start()
    {

    }

    void Update()
    {
      

        if (Timer.gameRunning && chasing)
        {//2.62 is max
            offset = new Vector3(player.transform.position.x, transform.position.y, 0);
            transform.position = offset;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            chasing = false;
        }

    }
}
