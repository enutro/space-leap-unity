using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStartGameAnimation : MonoBehaviour {
    public Transform player;
    public Rigidbody2D playerRigid;
    private Vector3 newPlayerPos;
    private Vector3 newPlayerVel;
    bool hasJumped = false;

    public Transform chasingLaser;
    public Transform rocket;
    public Transform initialLaser;
    public Vector3 laserPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (! Timer.gameRunning)
        {

            //Player walks in from the left and jumps on first platform.
            if (player.transform.position.x < -0.7f)
            {
                newPlayerPos = new Vector3(player.transform.position.x + 0.011f, player.transform.position.y, player.transform.position.z);
                player.transform.position = newPlayerPos;
            }
            else if (!hasJumped)
            {
                player.GetComponent<Animator>().SetBool("isJumping", true);
                hasJumped = true;
                playerRigid.velocity = new Vector3(0.675f, 4f, 0f);
                Object.Instantiate(initialLaser, laserPosition, transform.rotation);

            }else if (playerRigid.velocity.y == 0)
            {
                player.GetComponent<Animator>().SetBool("isIdle", true);
                player.GetComponent<Animator>().SetBool("isJumping", false);

            }


        }


    }
}
