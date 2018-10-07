using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpController : MonoBehaviour
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
    public Transform redlaser;

    private float XMinForceField = -0.9f;
    private float XMaxForceField = 0.9f;
    public Transform forcefield;
   public GameObject button;

    public bool CheckOnGround = false;
    public int highscore;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alive = true;

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        button.SetActive(false);

    }

    void Update()
    {
        if (alive && Timer.gameRunning)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && CheckOnGround == true)
            {
                GetComponent<Animator>().Play("", 0, 0f);
                GetComponent<Animator>().SetBool("isJumping", true);
                GetComponent<Animator>().SetBool("isIdle", false);
                rb.velocity = new Vector2(-jumpX, jumpY);
                CheckOnGround = false;
                transform.localScale = new Vector3(
          -1,
         transform.localScale.y,
         transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.RightArrow) && CheckOnGround == true)
            {
                GetComponent<Animator>().Play("", 0, 0f);

                GetComponent<Animator>().SetBool("isJumping", true);
                GetComponent<Animator>().SetBool("isIdle", false);
                rb.velocity = new Vector2(jumpX, jumpY);
                CheckOnGround = false;
                transform.localScale = new Vector3(
               1,
               transform.localScale.y,
               transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.UpArrow) && CheckOnGround == true)
            {
                GetComponent<Animator>().Play("", 0, 0f);

                GetComponent<Animator>().SetBool("isJumping", true);
                GetComponent<Animator>().SetBool("isIdle", false);
                rb.velocity = new Vector2(0, jumpY);
                CheckOnGround = false;

            }



            //Check Left and Right forceField.
            if (rb.transform.position.x > XMaxForceField && rb.velocity.x > 0)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x *= -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(XMaxForceField, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(-1.75f, 0f, 0);
            }
            if (rb.transform.position.x < XMinForceField && rb.velocity.x < 0)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x *= -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(XMinForceField, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(1.75f, 0f, 0);
            }

            //Generate new random laser
            if (rb.transform.position.y > (numOfLazersHopped * yDistanceBetweenLaser) + yStartLaser)
            {

                numOfLazersHopped++;
                randomLaserNumber = Random.Range(0, 2);
                if ( highscore == numOfLazersHopped)
                {
                    if (randomLaserNumber == 0)
                    {
                        Vector3 newScale = laser.transform.localScale;
                        newScale.x = -1;
                        laser.transform.localScale = newScale;


                        Object.Instantiate(laser, new Vector3(xLeftLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

                    }
                    else
                    {
                        Vector3 newScale = laser.transform.localScale;
                        newScale.x = 1;
                        laser.transform.localScale = newScale;
                        Object.Instantiate(laser, new Vector3(xRightLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

                    }
                }
                else {
                    if (randomLaserNumber == 0)
                    {
                        Vector3 newScale = redlaser.transform.localScale;
                        newScale.x = -1;
                        redlaser.transform.localScale = newScale;


                        Object.Instantiate(redlaser, new Vector3(xLeftLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

                    }
                    else
                    {
                        Vector3 newScale = redlaser.transform.localScale;
                        newScale.x = 1;
                        redlaser.transform.localScale = newScale;
                        Object.Instantiate(redlaser, new Vector3(xRightLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

                    }
                }
          
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "Laser" && rb.velocity.y <= 0)
        {
            CheckOnGround = true;
            GetComponent<Animator>().SetBool("isJumping", false);
            GetComponent<Animator>().SetBool("isIdle", true);
        }

        if (other.gameObject.tag == "Destroyer" )
        {
            alive = false;
            rb.velocity = new Vector3(0,0,0);
            GetComponent<Animator>().SetBool("isJumping", false);
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isDying", true);
            button.SetActive(true);

        }
    }
    public void OnCollision2DExit(Collision2D other)
    {

        if (other.gameObject.tag == "Laser")
        {
            CheckOnGround = false;
         
        }
    }


}