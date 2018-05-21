using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    bool jumpSuccess;


    public static float xDistanceBetweenEachtower = 2.671f;
    public float towerXPosition = 0;
    public float towerYPosition = 0.539f;
    public float lefttowerYPosition;

    // player main camera tag as Player
    public Transform player;
    // mutiple tower objects
    public Transform lefttower;
    public Transform righttower;

    // Minimum and Maximum number of towers
    private float playerY;
    private float playerX;
    private float startX;
    public float numOfLazersHopped = 0;
    private float distanceBetweenEachtower = 2.671f;
    bool currenttowerLeft;
    bool nexttowerLeft;
    int randomtowerNumber;
    int xtower;

    void Start()
    {
      

        
       

    }

    void Update()
    {

        // used to find the Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerY = player.transform.position.y;
        playerX = player.transform.position.x;


        // get the distance between the player and the tower GameObject
        float dist = Vector3.Distance(player.transform.position, this.transform.position);



        if (player.transform.position.y > (numOfLazersHopped * distanceBetweenEachtower) + 0.539f - xDistanceBetweenEachtower)
        {
            numOfLazersHopped++;


            Transform tower1 = Object.Instantiate(lefttower, new Vector3(towerXPosition, numOfLazersHopped * distanceBetweenEachtower + 0.539f - distanceBetweenEachtower), transform.rotation);
           Transform tower2 = Object.Instantiate(lefttower, new Vector3(towerXPosition, numOfLazersHopped * distanceBetweenEachtower + 0.539f ), transform.rotation);
            Physics2D.IgnoreCollision(tower1.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(tower2.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());


        }







    }
}