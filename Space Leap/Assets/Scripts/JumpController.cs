using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public float jumpX;
    public float jumpY;
    public bool CheckOnGround = false;
    public float vy;
    public bool adf;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics.IgnoreLayerCollision(11, 12);

    }

    void Update()
    {
        vy = rb.velocity.y;
        if (Input.GetKey(KeyCode.LeftArrow) && CheckOnGround == true)
        {
            rb.velocity = new Vector2(-jumpX, jumpY);
            CheckOnGround = false;
            transform.localScale = new Vector3(
      -1,
     transform.localScale.y,
     transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) && CheckOnGround==true)
        {
            rb.velocity = new Vector2(jumpX, jumpY);
            CheckOnGround = false;
            transform.localScale = new Vector3(
           1,
           transform.localScale.y,
           transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.UpArrow) && CheckOnGround == true)
        {
            rb.velocity = new Vector2(0, jumpY);
            CheckOnGround = false;
       
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        adf = other.gameObject.tag == "Laser";

        if (other.gameObject.tag == "Laser" && rb.velocity.y<=0.06&&(rb.transform.position.x<-0.15 && rb.transform.position.x > -0.33)|| (rb.transform.position.x > 0.15 && rb.transform.position.x < 0.33))
        {
            CheckOnGround = true;

        }
    }
    public void OnCollision2DExit(Collision2D other)
    {
        adf = other.gameObject.tag == "Laser";

        if (other.gameObject.tag == "Laser")
        {
            CheckOnGround = false;
        }
    }


}