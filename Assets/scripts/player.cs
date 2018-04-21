using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : fighter {
    [SerializeField]
    private HUD hud;
    [SerializeField]
    private Transform lastCheckpoint;
    // Use this for initialization
    void Start () {
        hud.playerbaractive(this);
        if (Playerstatus.Checkpoint != null)
        {
            setPosition(Playerstatus.Checkpoint);
        }
        setPosition(lastCheckpoint);
        base.Maxhp = Playerstatus.Maxhp;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public new void takedamage(int amount, float force)
    {
        if (base.takedamage(amount, force) == true)
        {
            hud.playerbarupdate();
        }
    }
    public Transform LastCheckpoint
    {
        get
        {
            return lastCheckpoint;
        }
        set
        {
            lastCheckpoint = value;
<<<<<<< HEAD
            Playerstatus.Checkpoint = value;
=======
>>>>>>> parent of 4856fa0... Deathscreen and Deathstate created. Animation needs work.
        }
    }
    public void setPosition(Transform position)
    {
        gameObject.transform.position = position.position;
    }
    public new int Maxhp
    {
        get
        {
            return base.Maxhp;
        }
        set
        {
            base.Maxhp = value;
            Playerstatus.Maxhp = value;
        }
    }
<<<<<<< HEAD
    public override void death()
    {
        //Time.timeScale = 0;
        Instantiate(Deatheffect, gameObject.transform.position, gameObject.transform.rotation);
        Model.active = false;
    }
=======
>>>>>>> parent of 4856fa0... Deathscreen and Deathstate created. Animation needs work.

}
