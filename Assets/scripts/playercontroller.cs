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
    private float wallcheckradius; //radius for the overlap circles used for ground and wall detection
    [SerializeField]
    private bool isgrounded;
    [SerializeField]
    private LayerMask whatisground; //Filters out gameobjects by layer to indicate what is ground
    [SerializeField]
    private int slowspeed; 
    [SerializeField]
    private Transform rightwalldetection;
    [SerializeField]
    private Transform leftwalldetection;
    [SerializeField]
    private int walljumptime;
    [SerializeField]
    private int walljumpjumpmult; //Mutliplyer for walljumping for y movement.
    [SerializeField]
    private int walljumpmovemult; //Multiplyer for walljumping and x movement.
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

    void Start()
    {
        fallcheck = INVALIDFALLCHECK; //sets fallcheck to an invaild amount on start to avoid false postivies with jumping
    }

    void FixedUpdate()
    {
        updateinputs();
        walljump();

        if (fallcheck != INVALIDFALLCHECK)
        {
            grabcheck();
        }
        isgrounded = Physics2D.OverlapCircle(ground.position, groundcircleradius, whatisground); //creates an overlap circle to detect if the terrian below the player is ground
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
            Time.timeScale = 0; //"pauses" the game.
            pausemenu.SetActive(true); 
        }
        if (attack1)
        {
            Attack(1);
        }
        else


            fallcheck = gameObject.transform.position.y; //gets the y position to compare it with current players y position next fixed update
    }
    /**
     * Simple method that updates user the inputs
     */
    private void updateinputs()
    {
        xaxis = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        escape = Input.GetButtonDown("Cancel");
        attack1 = Input.GetButtonDown("Fire1");
    }
    /*
     * method for checking and preforming wallgrabs 
     */
    private void grabcheck()
    {
        //Creates overlap circles to the left and right of the player.
        bool cangrableft = Physics2D.OverlapCircle(leftwalldetection.position, wallcheckradius, whatisground);
        bool cangrabright = Physics2D.OverlapCircle(rightwalldetection.position, wallcheckradius, whatisground);
            if (cangrableft == true)
            {
                if (xaxis < 0) //if the player is currently holding the button forcing them aganist the wall
                {
                if (haswalljumped == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0); //if the player has walljumped and hits the wall again all upward moblity is eliminated
                }
                if (gameObject.transform.position.y < fallcheck)
                {
                    rb.drag = slowspeed; ///emulates the effect of "Grabbing and sliding down the wall
                    if (jump)
                    {
                        SideJump(true, ent.Jumpheight * walljumpjumpmult, ent.Movementspeed * walljumpmovemult, xaxis);
                        iswalljumping = true;
                        haswalljumped = true;
                    }
                }
                }
            }
            //This mirriors the code for grabbingright
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
                rb.drag = 0; //returns drag to normal returning the falling physics to normal.
        }
        }
    

    private void walljump()
    {
        if (iswalljumping == true)
        {
            fixedupdatecounter++;
            if (walljumptime - fixedupdatecounter > 0) //tracks and compares the number of updates the walljump will occur.
            {
                xaxis = xaxis * -1; //reverses the player x axis during a walljump. creating a "arc" for their jumps
            }
            else
            {
                fixedupdatecounter = 0;
                iswalljumping = false;
            }
        }
    }

    /**
     * getter and setter for isgrounded flag
     */
    public bool Isgrounded
    {
        get { return isgrounded; }
        set { isgrounded = value; }
    }
    /*
     * getting for groundmanualset
     */
    public bool Groundmanualset
    {
        get { return isgrabbing; }
        set { isgrabbing = value; }

    }

}