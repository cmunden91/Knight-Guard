using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private player play;
    [SerializeField]
    private Transform ground;
    [SerializeField]
    private Transform ceiling;
    [SerializeField]
    private float groundcircleradius;
    [SerializeField]
    private bool isgrounded;
    [SerializeField]
    private LayerMask whatisground;
    [SerializeField]
    private int slowspeed;
    private bool isgrabbing = false;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
	{
        if (isgrabbing == false)
        {
            isgrounded = Physics2D.OverlapCircle(ground.position, groundcircleradius, whatisground);
            if (Input.GetButtonDown("Jump"))
            {
                if (isgrounded == true)
                {
                    Jump();
                }
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                Moveright();
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                Moveleft();
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0 && Input.GetButtonDown("Jump"))
            {
                Jump();
                Moveright();
            }
            if (Input.GetAxis("Horizontal") < 0 && Input.GetButtonDown("Jump"))
            {
                Jump();
                Moveleft();
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

    public void Wallgrab(bool grabbing)
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

    }
    public void Moveright()
    {
        {
            int move = play.Movementspeed;
            rb.velocity = new Vector2(play.Movementspeed, rb.velocity.y);
        }
    }
    public void Moveleft()
    {
        int move = play.Movementspeed;
        rb.velocity = new Vector2(0 - play.Movementspeed, rb.velocity.y);
    }
    public void Jump()
    {
        int jump = play.Jumpheight;
        rb.velocity = Vector2.up * jump;
    }

}