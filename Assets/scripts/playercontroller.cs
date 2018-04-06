﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : controller
{


    [SerializeField]
    private Transform ground;
    [SerializeField]
    private Transform ceiling;
    [SerializeField]
    private float groundcircleradius;
    [SerializeField]
    private float wallcheckradius;
    [SerializeField]
    private bool isgrounded;
    [SerializeField]
    private LayerMask whatisground;
    [SerializeField]
    private int slowspeed;
    [SerializeField]
    private Transform rightwalldetection;
    [SerializeField]
    private Transform leftwalldetection;
    [SerializeField]
    private int walljumptime;
    [SerializeField]
    private int walljumpjumpmult;
    [SerializeField]
    private int walljumpmovemult;
    [SerializeField]
    private GameObject pausemenu;
    private bool isgrabbing = false;
    private float fallcheck;
    private bool isfalling = false;
    private bool iswalljumping = false;
    private int fixedupdatecounter = 0;
    private float xaxis;
    private const float INVALIDFALLCHECK = -9999999999999;

    // Use this for initialization
    void Start()
    {
        fallcheck = -9999999999999;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xaxis = Input.GetAxis("Horizontal");
        walljump();

            if (fallcheck != INVALIDFALLCHECK)
            {
                grab();
            }
            isgrounded = Physics2D.OverlapCircle(ground.position, groundcircleradius, whatisground);
            if (Input.GetButtonDown("Jump"))
            {
                if (isgrounded == true)
                {
                    Jump(ent.Jumpheight);
                }
            }
            if (xaxis > 0)
            {
                Moveright(ent.Movementspeed, xaxis);
            }
            if (xaxis < 0)
            {
                Moveleft(ent.Movementspeed, xaxis);
            }
            if (xaxis == 0)
            {
                Idle();
            }
            if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            pausemenu.SetActive(true);
        }
            if (Input.GetButtonDown("Fire1"))
        {
            Attack(1);
        }
            else 


            fallcheck = gameObject.transform.position.y;
        }
    private void grab()
    {
        if (gameObject.transform.position.y < fallcheck)
        {
            bool cangrableft = Physics2D.OverlapCircle(leftwalldetection.position, wallcheckradius, whatisground);
            bool cangrabright = Physics2D.OverlapCircle(rightwalldetection.position, wallcheckradius, whatisground);
            if (cangrableft == true)
            {
                if (xaxis < 0)
                {
                    rb.drag = slowspeed;
                    if (Input.GetButtonDown("Jump"))
                    {
                        SideJump(true, ent.Jumpheight * walljumpjumpmult, ent.Movementspeed * walljumpmovemult, xaxis);
                        iswalljumping = true;
                    }
                }
            }
            else if (cangrabright == true)
            {
                if (xaxis > 0)
                {
                    rb.drag = slowspeed;
                    if (Input.GetButtonDown("Jump"))
                    {
                        SideJump(false, ent.Jumpheight * walljumpjumpmult, ent.Movementspeed * walljumpmovemult, xaxis);
                        iswalljumping = true;
                    }
                }
            }
            else
            {
                rb.drag = 0;
            }
        }
    }
    private void walljump()
    {
        if (iswalljumping == true)
        {
            fixedupdatecounter++;
            if (walljumptime - fixedupdatecounter > 0)
            {
                xaxis = xaxis * -1;
            }
            else
            {
                fixedupdatecounter = 0;
                iswalljumping = false;
            }
        }
    }

	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision);
	}
    [HideInInspector]
    public bool Isgrounded
    {
        get { return isgrounded; }
        set { isgrounded = value; }
    }
    public bool Groundmanualset
    {
        get { return isgrabbing; }
        set { isgrabbing = value; }

    }

/*    public void Wallgrab(bool grabbing)
    {
        isgrabbing = grabbing;
        isgrounded = grabbing;
        if (grabbing == true)
        {
            rb.drag = slowspeed;
        }
        else
        {
            rb.drag = 0;
        }

    } */

}