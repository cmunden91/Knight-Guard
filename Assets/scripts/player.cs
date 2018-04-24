using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    /**
     * primary script for the player. tracking attributes like spawn points while also acting as hooks for various different atrributes
     * like the Animator and Hud elements */

    [SerializeField]
    private HUD hud;
    [SerializeField]
    private Transform spawnpoint;
    [SerializeField]
    private Animator playeranimator;
    [SerializeField]
    private GameObject deathscreen;
    [SerializeField]
    private Rigidbody2D rb;

    void Start () {
        hud.playerbaractive(this); //activates the HUD for jthe player. Activating the health bar
        if (Playerstatus.Currentdata.LastCheckpoint != null) //If there is previous checkpoint data stored
        {
            spawnpoint = Playerstatus.Currentdata.LastCheckpoint;
        }
        gameObject.transform.position = spawnpoint.position; //If no checkpoint is found it will use the default spawn assigned in the inspector
        base.Maxhp = Playerstatus.Currentdata.MaxHP;
		
	}

    /*
     * overridden takedamage method in the inherited class. int amount is the amount of damage and float force is the force of knockback for being hit
     */
    public new void takedamage(int amount, float force)
    {
        base.takedamage(amount, force); //calls the inherited class to take the damage
        hud.playerbarupdate(); 
        
    }
    /*
     * Getting and setter for spawnpoint
     */
    public Transform Spawnpoint
    {
        get
        {
            return spawnpoint;
        }
        set
        {
            spawnpoint = value;
            Playerstatus.Currentdata.LastCheckpoint = value;
        }
    }
    /*
     * method to set the player posiiton. Transform position is the transform containing the position to move too.
     */
    public void setPosition(Transform position)
    {
        gameObject.transform.position = position.position;
    }
    /**
     * overridden getter and setter for MaxHP
     */
    public override int Maxhp
    {
        get
        {
            return base.Maxhp; //Uses the inherited Maxhp getter
        }
        set
        {
            base.Maxhp = value;
            Playerstatus.Currentdata.MaxHP = value; //updates the playerstatus maxhp
            hud.playerbarupdate();
        }
    }
    /*
     * overridden getter and setter for currenthp
     */
    public override int Currenthp
    {
        get
        {
            return base.Currenthp;
        }

        set
        {
            base.Currenthp = value;
            hud.playerbarupdate();
        }
    }
    /**
     * overridden method for death(!).
     */
    public override void death()
    {
        deathscreen.SetActive(true); //activates the deathscreen UI element.
        rb.constraints = RigidbodyConstraints2D.FreezePosition; //Frrezes the x and y movement for the player. preventing them from moving
        Model.SetActive(false); //hides the player model
        Instantiate(Deatheffect, gameObject.transform.position, gameObject.transform.rotation); //Creates the death particle effect on player location

    }

}
