﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected entity ent;


    public void Moveright()
    {  
            rb.velocity = new Vector2(ent.Movementspeed, rb.velocity.y);
        
    }
    public void Moveright(float multiplier)
    {
        rb.velocity = rb.velocity = new Vector2((ent.Movementspeed*multiplier), rb.velocity.y);
    }
    public void Moveleft()
    {
        rb.velocity = new Vector2(0 - ent.Movementspeed, rb.velocity.y);
    }
    public void Moveleft(float multiplier)
    {
        rb.velocity = new Vector2((0 - ent.Movementspeed*multiplier), rb.velocity.y);
    }
    public void Jump()
    {
        int jump = ent.Jumpheight;
        rb.velocity = Vector2.up * jump;
    }
    public void SideJump(bool side)
    {
        if (side == false)
        {
            
            Moveright(10f);
            Jump();
        }
        if (side == true)
        {
            Moveleft(10f);
            Jump();
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
