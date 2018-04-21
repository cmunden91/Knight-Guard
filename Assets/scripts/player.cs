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
        if (Playerstatus.Currentdata.transform != null)
        {
            setPosition(Playerstatus.Currentdata.transform);
        }
        setPosition(lastCheckpoint);
        base.Maxhp = Playerstatus.Currentdata.MaxHP;
		
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
            Playerstatus.Currentdata.LastCheckpoint = value;
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
            Playerstatus.Currentdata.MaxHP = value;
        }
    }
    public override void death()
    {
        playeranimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        playeranimator.SetBool("isdead", true);
        Time.timeScale = 0;
    }

}
