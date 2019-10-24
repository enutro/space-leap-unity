using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class animationJumpTransition : MonoBehaviour {
    Animator animator;
    public Transform player;
    private Rigidbody2D rb;
    bool isJumping =false;
    public bool alive;
    public float jumpX;
    public float jumpY;
    public bool CheckOnGround = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        alive = true;

    }

    // Update is called once per frame
    void Update()
    {



     

        if (alive && Timer.gameRunning)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && CheckOnGround == true)
            {
                animator.SetBool("jump", true);

                rb.velocity = new Vector2(-jumpX, jumpY);
                CheckOnGround = false;
                transform.localScale = new Vector3(
          -1,
         transform.localScale.y,
         transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.RightArrow) && CheckOnGround == true)
            {
                animator.SetBool("jump", true);

                rb.velocity = new Vector2(jumpX, jumpY);
                CheckOnGround = false;
                transform.localScale = new Vector3(
               1,
               transform.localScale.y,
               transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.UpArrow) && CheckOnGround == true)
            {
                animator.SetBool("jump", true);

                rb.velocity = new Vector2(0, jumpY);
                CheckOnGround = false;

            }


          




        }
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Laser" && rb.velocity.y <= 0)
        {

            CheckOnGround = true;

        }
        if (other.gameObject.tag == "Destroyer")
        {
            alive = false;
            rb.velocity = new Vector3(5, 0, 0);
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
