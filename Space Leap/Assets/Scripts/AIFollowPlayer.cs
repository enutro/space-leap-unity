using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class AIFollowPlayer : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public bool chasing=true;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    void start() {
    
    }

    void Update()
    {
        if (Timer.gameRunning && chasing)
        {
            if (speed < 0.03)
            {
                speed = speed + 0.000005f;
            }
            if(player.transform.position.y < -0.45f)
            {
                speed = speed + 0.01f;

            }
            offset = new Vector3(player.transform.position.x-0.59f, transform.position.y + speed, 0);
            transform.position = offset;
        }
        else
        {
            offset = new Vector3(player.transform.position.x - 0.59f, transform.position.y , 0);
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
