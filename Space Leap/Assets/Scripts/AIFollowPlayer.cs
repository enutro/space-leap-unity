using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class AIFollowPlayer : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public bool chasing=true;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public bool moveHasBeenMade = false;
    public GameObject ufoIndicator;
    void start() {
        ufoIndicator.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            moveHasBeenMade = true;

        }

        if (Timer.gameRunning && chasing && moveHasBeenMade)
        {//2.62 is max
            if (speed < 0.023)
            {
                speed = speed + 0.000001f;
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

        if (transform.position.y < player.transform.position.y-2.1f)
        {
            ufoIndicator.SetActive(true);

        }
        else
        {
            ufoIndicator.SetActive(false);

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
