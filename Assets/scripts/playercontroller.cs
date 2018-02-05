using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private player play;
    private BoxCollider2D ground;
    private BoxCollider2D ceiling;
    private bool isstanding;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        play = GetComponent<player>();
        
        isstanding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isstanding == true)
            {
                int jump = play.Jumpheight;
                rb.velocity = Vector2.up * jump;
            }
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            int move = play.Movementspeed;
            rb.velocity = new Vector2(play.Movementspeed, rb.velocity.y);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            int move = play.Movementspeed;
            rb.velocity = new Vector2(0 - play.Movementspeed, rb.velocity.y);
        }
        
    }



}