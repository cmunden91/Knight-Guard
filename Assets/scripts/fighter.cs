using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : entity {
    [HideInInspector, SerializeField]
    private int currenthp;
    [HideInInspector, SerializeField]
    private int maxhp;
    [HideInInspector, SerializeField]
    private bool hostile;

    public fighter(string name, bool interactable, int currenthp, int maxhp, bool hostile) : base(name, interactable)
    {
        this.currenthp = currenthp;
        this.maxhp = maxhp;
        this.hostile = hostile;
    }

    [ExposeProperty] public int Currenthp
    {
        get { return currenthp; }
        set { currenthp = value; }
    }

    [ExposeProperty]
    public int Maxhp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    [ExposeProperty]
    public bool Hostile
    {
        get { return hostile; }
        set { hostile = value; }
    }

}