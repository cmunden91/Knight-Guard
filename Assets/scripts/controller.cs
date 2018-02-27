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


    public void Moveright()
    {
        transform.position += Vector3.right * Time.deltaTime * ent.Movementspeed;
        
    }
    public void Moveright(float multiplier)
    {
        transform.position += Vector3.right * Time.deltaTime * (ent.Movementspeed*multiplier);
    }
    public void Moveleft()
    {
        transform.position += Vector3.left * Time.deltaTime * ent.Movementspeed;
    }
    public void Moveleft(float multiplier)
    {
        transform.position += Vector3.left * Time.deltaTime * (ent.Movementspeed*multiplier);
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
