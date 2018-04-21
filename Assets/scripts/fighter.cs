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
    [SerializeField]
    private GameObject model;
    [SerializeField]
    private GameObject deatheffect;
    private bool invincible;
    private float timeoflasthit;



    [HideInInspector]
    public virtual int Currenthp
    {
        get { return currenthp; }
        set
        {
            if ((value) >= maxhp)
            {
                currenthp = maxhp;
            }
            else
            {
                currenthp = value;
            }   
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
        Instantiate(deatheffect, gameObject.transform.position, gameObject.transform.rotation);
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
    public GameObject Model
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
        }
    }
    public GameObject Deatheffect
    {
        get
        {
            return deatheffect;
        }
        set
        {
            deatheffect = value;
        }
    }
}