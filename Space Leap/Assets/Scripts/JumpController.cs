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
    private bool forceFieldHit = false;
    private float XMinForceField = -0.9f;
    private float XMaxForceField = 0.9f;
    public Transform forcefield;
   public GameObject button;
    public float jumpPosition;
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
            Touch touch;
            bool isTouch = false;
            if (Input.touchCount > 0)
            {
                isTouch = true;
                touch = Input.touches[0];
                if (((isTouch && touch.position.x < Screen.width / 3)) && CheckOnGround == true)
                {
                    jumpPosition = rb.transform.position.x;

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
                if (((isTouch && touch.position.x > (Screen.width / 3)*2)) && CheckOnGround == true)
                {
                    jumpPosition = rb.transform.position.x;

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
                if (((isTouch && touch.position.x < (Screen.width / 3) * 2)) && ((isTouch && touch.position.x > (Screen.width / 3)))  && CheckOnGround == true)
                {
                    GetComponent<Animator>().Play("", 0, 0f);

                    GetComponent<Animator>().SetBool("isJumping", true);
                    GetComponent<Animator>().SetBool("isIdle", false);
                    rb.velocity = new Vector2(0, jumpY);
                    CheckOnGround = false;

                }


            }

            if (Input.GetKey(KeyCode.LeftArrow) && CheckOnGround == true)
            {
                jumpPosition = rb.transform.position.x;

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
                jumpPosition = rb.transform.position.x;

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

            //Closer forcefields.
            if(jumpPosition < 0 && rb.transform.position.x > 0.55f)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x *= -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(0.55f, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(-2f, rb.velocity.y, 0);
                forceFieldHit = true;
            }
            if (jumpPosition > 0 && rb.transform.position.x < -0.55f)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x *= -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(-0.55f, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(2f, rb.velocity.y, 0);
                forceFieldHit = true;
            }



            //Check Left and Right forceField.
            if (rb.transform.position.x > XMaxForceField && rb.velocity.x > 0)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x *= -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(XMaxForceField, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(-2f, 0f, 0);
                forceFieldHit = true;

            }
            if (rb.transform.position.x < XMinForceField && rb.velocity.x < 0)
            {
                Vector3 newScale = forcefield.transform.localScale;
                newScale.x *= -1;
                forcefield.transform.localScale = newScale;
                Object.Instantiate(forcefield, new Vector3(XMinForceField, rb.transform.position.y, 0), transform.rotation);
                rb.velocity = new Vector3(2f, 0f, 0);
                forceFieldHit = true;
            }

            if(forceFieldHit && rb.velocity.x < 0)
            {
                if (rb.transform.position.x < 0.276f)
                {
                    rb.velocity = new Vector3(0f, rb.velocity.y, 0);
                }
            }
            else if (forceFieldHit && rb.velocity.x > 0)
            {
                if (rb.transform.position.x > -0.280f)
                {
                    rb.velocity = new Vector3(0f, rb.velocity.y, 0);
                }

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
                        newScale.x = 1;
                        laser.transform.localScale = newScale;


                        Object.Instantiate(laser, new Vector3(xLeftLaser, numOfLazersHopped * yDistanceBetweenLaser + yStartLaser), transform.rotation);

                    }
                    else
                    {
                        Vector3 newScale = laser.transform.localScale;
                        newScale.x = -1;
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
            rb.velocity = new Vector2(0, rb.velocity.y);
            forceFieldHit = false;
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