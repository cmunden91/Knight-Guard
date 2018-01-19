using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {
    Rigidbody2D rb;
    player play;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        play = GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            int jump = play.Jumpheight;
            rb.velocity = Vector2.up * jump;
        }
        if (Input.GetAxis ("Horizontal") > 0)
        {
            int move = play.Movementspeed;
            rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            int move = play.Movementspeed;
            rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }
    }
}
