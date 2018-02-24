using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected entity ent;


    public void Moveright()
    {
        {
            int move = ent.Movementspeed;
            rb.velocity = new Vector2(ent.Movementspeed, rb.velocity.y);
        }
    }
    public void Moveleft()
    {
        int move = ent.Movementspeed;
        rb.velocity = new Vector2(0 - ent.Movementspeed, rb.velocity.y);
    }
    public void Jump()
    {
        int jump = ent.Jumpheight;
        rb.velocity = Vector2.up * jump;
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
