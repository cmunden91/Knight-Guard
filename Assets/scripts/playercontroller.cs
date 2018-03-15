using System.Collections;
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
    private bool isgrabbing = false;
    private float fallcheck;
    private bool isfalling = false;

    // Use this for initialization
    void Start()
    {
        fallcheck = -9999999999999;
    }

    // Update is called once per frame
    void FixedUpdate()
	{
        if (fallcheck != -9999999999999)
        {
            if (gameObject.transform.position.y < fallcheck)
            {
                bool cangrableft = Physics2D.OverlapCircle(leftwalldetection.position, wallcheckradius, whatisground);
                bool cangrabright = Physics2D.OverlapCircle(rightwalldetection.position, wallcheckradius, whatisground);
                if (cangrableft == true)
                {
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        rb.drag = slowspeed;
                        if (Input.GetButtonDown("Jump"))
                        {
                            SideJump(false, ent.Jumpheight, ent.Movementspeed, Input.GetAxis("Horizontal"));
                        }
                    }
                }
                else if (cangrabright == true)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        rb.drag = slowspeed;
                        if (Input.GetButtonDown("Jump"))
                        {
                            SideJump(true, ent.Jumpheight, ent.Movementspeed, Input.GetAxis("Horizontal"));
                        }
                    }
                }
                else
                {
                    rb.drag = 0;
                }
            }
        }
            isgrounded = Physics2D.OverlapCircle(ground.position, groundcircleradius, whatisground);
            if (Input.GetButtonDown("Jump"))
            {
                if (isgrounded == true)
                {
                    Jump(ent.Jumpheight);
                }
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                Moveright(ent.Movementspeed, Input.GetAxis("Horizontal"));
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                Moveleft(ent.Movementspeed, Input.GetAxis("Horizontal"));
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
            Idle();
            }


        fallcheck = gameObject.transform.position.y;  
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