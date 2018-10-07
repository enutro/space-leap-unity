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

            offset = new Vector3(player.transform.position.x-0.55f, transform.position.y + speed, 0);
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
