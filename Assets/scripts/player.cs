using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : fighter {
    [SerializeField]
    private HUD hud;
    [SerializeField]
    private Transform lastCheckpoint;
    [SerializeField]
    private Animator playeranimator;
    [SerializeField]
    private AnimationClip deathanimation;
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
            Playerstatus.Checkpoint = value;
        }
    }
    public void setPosition(Transform position)
    {
        gameObject.transform.position = position.position;
    }
    public override int Maxhp
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
    public override void death()
    {
        //Time.timeScale = 0;
        Instantiate(Deatheffect, gameObject.transform.position, gameObject.transform.rotation);
        Model.active = false;
    }

}
