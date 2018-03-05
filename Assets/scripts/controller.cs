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


    public void Moveright()
    {
        if (isfacingright == false)
        {
            model.transform.Rotate(new Vector3(0, 180, 0));
            isfacingright = true;
        }
        transform.position += Vector3.right * Time.deltaTime * ent.Movementspeed;
        animator.SetFloat("speed", Time.deltaTime * ent.Movementspeed);


    }
    public void Moveright(float multiplier)
    {
        transform.position += Vector3.right * Time.deltaTime * (ent.Movementspeed*multiplier);
    }
    public void Moveleft()
    {
        if (isfacingright == true)
        {
            model.transform.Rotate(new Vector3(0, -180, 0));
            isfacingright = false;
        }
        transform.position += Vector3.left * Time.deltaTime * ent.Movementspeed;
        animator.SetFloat("speed", Time.deltaTime * ent.Movementspeed);
    }
    public void Moveleft(float multiplier)
    {
        transform.position += Vector3.left * Time.deltaTime * (ent.Movementspeed*multiplier);
    }
    public void Idle()
    {
        animator.SetFloat("speed", 0);
    }
    public void Jump()
    {
        rb.velocity = Vector2.up * ent.Jumpheight;
    }
    public void SideJump(bool side)
    {
        if (side == false)
        {
            Jump();
            Moveright(7f);
        }
        if (side == true)
        {
            Jump();
            Moveleft(7f);
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
