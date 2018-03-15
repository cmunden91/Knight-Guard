using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected entity ent;
    [SerializeField]
    protected Transform transf;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private bool isfacingright = true;
    [SerializeField]
    private GameObject model;


    public void Moveright(float move, float axis)
    {
        if (isfacingright == false)
        {
            model.transform.Rotate(new Vector3(0, 180, 0));
            isfacingright = true;
        }
       rb.velocity = new Vector2(move * axis, rb.velocity.y);
        animator.SetFloat("speed", move * axis);


    }
    public void Moveleft(float move, float axis)
    {
        if (isfacingright == true)
        {
            model.transform.Rotate(new Vector3(0, -180, 0));
            isfacingright = false;
        }
        rb.velocity = new Vector2(move * axis, rb.velocity.y);
        animator.SetFloat("speed", (move * axis)*-1);
    }

    public void Idle()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetFloat("speed", 0);
    }
    public void Jump(float jumpheight)
    {
        rb.velocity = Vector2.up * jumpheight;
    }
    public void SideJump(bool side, float jumpheight, float move, float axis)
    {
        if (side == false)
        {
            Jump(jumpheight);
            Moveright(move, axis);
        }
        if (side == true)
        {
            Jump(jumpheight);
            Moveleft(move, axis);
        }
    }
    [HideInInspector]
    public Rigidbody2D Rb
    {
        get { return rb; }
        set { value = rb; }
    }
    [HideInInspector]
    public entity Ent
    {
        get { return ent; }
        set { value = ent; }
    }
}
