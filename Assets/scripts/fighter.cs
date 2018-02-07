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
    private bool hostile;

    public fighter(string name, bool interactable, int currenthp, int maxhp, bool hostile, int movementspeed, int jumpheight) : base(name, interactable, movementspeed, jumpheight)
    {
        this.currenthp = currenthp;
        this.maxhp = maxhp;
        this.hostile = hostile;
    }

    [HideInInspector]
    public int Currenthp
    {
        get { return currenthp; }
        set { currenthp = value; }
    }

    [HideInInspector]
    public int Maxhp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    [HideInInspector]
    public bool Hostile
    {
        get { return hostile; }
        set { hostile = value; }
    }
}