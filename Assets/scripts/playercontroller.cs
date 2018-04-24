using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : Controller
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
    private bool jump;
    private bool escape;
    private bool attack1;
    [SerializeField]
    private bool haswalljumped = false;
    private const float INVALIDFALLCHECK = -9999999999999;

    // Use this for initialization
    void Start()
    {
        fallcheck = INVALIDFALLCHECK;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateinputs();
        walljump();

        if (fallcheck != INVALIDFALLCHECK)
        {
            grabcheck();
        }
        isgrounded = Physics2D.OverlapCircle(ground.position, groundcircleradius, whatisground);
        if (isgrounded)
        {
            haswalljumped = false;
            if (jump)
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
        if (escape)
        {
            Time.timeScale = 0;
            pausemenu.SetActive(true);
        }
        if (attack1)
        {
            Attack(1);
        }
        else


            fallcheck = gameObject.transform.position.y;
    }
    private void updateinputs()
    {
        xaxis = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        escape = Input.GetButtonDown("Cancel");
        attack1 = Input.GetButtonDown("Fire1");
    }
    private void grabcheck()
    {
        bool cangrableft = Physics2D.OverlapCircle(leftwalldetection.position, wallcheckradius, whatisground);
        bool cangrabright = Physics2D.OverlapCircle(rightwalldetection.position, wallcheckradius, whatisground);
            if (cangrableft == true)
            {
                if (xaxis < 0)
                {
                if (haswalljumped == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
                if (gameObject.transform.position.y < fallcheck)
                {
                    rb.drag = slowspeed;
                    if (jump)
                    {
                        SideJump(true, ent.Jumpheight * walljumpjumpmult, ent.Movementspeed * walljumpmovemult, xaxis);
                        iswalljumping = true;
                        haswalljumped = true;
                    }
                }
                }
            }
            else if (cangrabright == true)
            {
                if (xaxis > 0)
                {
                if (haswalljumped == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
                if (gameObject.transform.position.y < fallcheck)
                {
                    rb.drag = slowspeed;
                    if (jump)
                    {
                        SideJump(false, ent.Jumpheight * walljumpjumpmult, ent.Movementspeed * walljumpmovemult, xaxis);
                        iswalljumping = true;
                        haswalljumped = true;
                    }
                }
                }
            }
            else
            {
                rb.drag = 0;
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

}