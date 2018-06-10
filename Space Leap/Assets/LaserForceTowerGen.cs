using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserForceTowerGen : MonoBehaviour
{


    public float jumpX;
    public float jumpY;
    private Rigidbody2D rb;
    public bool alive;
    public float yStartTower;
    public float yDistanceBetweenTower;

    public Transform tower;

    public float yDistanceBetweenLaser;
    public float xRightLaser;
    public float xLeftLaser;
    public int numOfLazersHopped;
    public int randomLaserNumber;
    public float yStartLaser;
    public Transform laser;

    private float XMinForceField = -1f;
    private float XMaxForceField = 1f;
    public Transform forcefield;

    public bool CheckOnGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alive = true;
    }

    void Update()
    {
        if (alive && Timer.gameRunning)
        {




            //Check Left and Right forceField.
            if (rb.transform.position.x >= XMaxForceField && rb.velocity.x > 0)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x = -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(XMaxForceField, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(-3f, 0f, 0);
            }
            if (rb.transform.position.x <= XMinForceField && rb.velocity.x < 0)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x = 1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(XMinForceField, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(3f, 0f, 0);
            }

            //Generate new random laser
            if (rb.transform.position.y > (numOfLazersHopped * yDistanceBetweenLaser) + yStartLaser)
            {

                numOfLazersHopped++;
                randomLaserNumber = Random.Range(0, 2);

                if (randomLaserNumber == 0)
                {
                    Vector3 newScale = laser.transform.localScale;
                    newScale.x = -1;
                    laser.transform.localScale = newScale;
                    Object.Instantiate(laser, new Vector3(xLeftLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);
                    Object.Instantiate(tower, new Vector3(0, numOfLazersHopped * yDistanceBetweenTower + yStartTower), transform.rotation);

                }
                else
                {
                    Vector3 newScale = laser.transform.localScale;
                    newScale.x = 1;
                    laser.transform.localScale = newScale;
                    Object.Instantiate(laser, new Vector3(xRightLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);
                    Object.Instantiate(tower, new Vector3(0, numOfLazersHopped * yDistanceBetweenTower + yStartTower), transform.rotation);

                }
            }
        }
    }




}