using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    Rigidbody2D rb;
    public bool isGrounded;
    public float jumpHeight =5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundCheck.position,1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }

        if (Input.GetButton("Horizontal"))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"),rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetButtonDown("Vertical") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpHeight);
        }

    }
}
