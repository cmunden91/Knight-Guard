using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : entity
{
    [SerializeField]
    private int currenthp;
    [SerializeField]
    private int maxhp;
    [SerializeField]
    private bool isHostile;
    [SerializeField]
    private float invinciblitytime;
    [SerializeField]
    protected int damageofattack;
    [SerializeField]
    protected float forceofattack;
    private bool invincible;
    private float timeoflasthit;



    [HideInInspector]
    public int Currenthp
    {
        get { return currenthp; }
        set
        {
            currenthp = value;
            if (currenthp <= 0)
            {
                if(this is player)
                {
                    this.death();
                }
                death();
            }
        }
    }

    [HideInInspector]
    public virtual int Maxhp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    [HideInInspector]
    public bool IsHostile
    {
        get { return isHostile; }
        set { isHostile = value; }
    }
    public bool takedamage(int amount, float force)
    {

        if (invincible == false)
        {
            Currenthp = Currenthp - amount;
            controller.knockback(force);
            timeoflasthit = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }



    public virtual void death()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        if (invincible == true)
        {
            if (Time.time >= (timeoflasthit + invinciblitytime))
            {
                invincible = false;
            }
        }
    }
}