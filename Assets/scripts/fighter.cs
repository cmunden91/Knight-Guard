using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Entity
{
    /**
     * Script for all "fighters" (entites capable of combat) inheriting from Entity
     */
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

    /*
     * Vritual getter and setter for currenthealth. Note that this method is expected to be used with "+=" or be addeded with the new value.
     */
    public virtual int Currenthp
    {
        get
        {
            return currenthp;
        }
        set
        {
            if ((value) >= maxhp) //if the heal value would exceed the fighters Max HP
            {
                currenthp = maxhp; //Let the maxHP of fighter be the new currentHP
            }
            else
            {
                currenthp = value;
            }   
            if (currenthp <= 0)
            {
                    this.death(); //Always calls the subclass's death method if overritten rather then the parent.
                
            }
        }
    }

    //Getter and setter for MaxHP
    public virtual int Maxhp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    //Getter and setter for isHostile flag
    public bool IsHostile
    {
        get { return isHostile; }
        set { isHostile = value; }
    }
    /**
     * method for taking damage, taking int amount for the amount of damage and float force for the amount of knockback the attack has
     */
    public bool takedamage(int amount, float force)
    {

        if (invincible == false)
        {
            Currenthp = Currenthp - amount;
            controller.knockback(force); //calls the parent controllers knockback method
            timeoflasthit = Time.time; //saves the time of the last hit
            return true;
        }
        else
        {
            return false;
        }
    }



    public virtual void death()
    {
        Instantiate(deatheffect, gameObject.transform.position, gameObject.transform.rotation); //creates the particle effect for death.
        Destroy(gameObject); //deletes itself on death
    }

    public void FixedUpdate()
    {
        if (invincible == true) 
        {
            if (Time.time >= (timeoflasthit + invinciblitytime)) //Checks if the time of the last hit plus the invisablity time is higher. If so sets invinicblity to false
            {
                invincible = false;
            }
        }
    }
    /**
     * getter and setter for the fighters model.
     */
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
    /*
     * Getter and setter for the particle death effect.
     */
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