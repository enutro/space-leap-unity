using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class AIFollowPlayer : MonoBehaviour
{

    public float speed;
    public GameObject player;

    void start() {
        speed = 0.5f;
    }

    void Update()
    {
        if (Timer.gameRunning) {
            Vector3 localPosition = player.transform.position+new Vector3(-0.25f,0,0) - transform.position;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            float maxSpeed = 2.15f;
            if (speed < maxSpeed)
            {
                speed = speed + 0.0025f;
            }
        }
    }
}
