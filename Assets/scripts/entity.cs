using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class entity : ExposableMonobehaviour
{
    [HideInInspector, SerializeField]
    private string name;
    [HideInInspector, SerializeField]
    private bool interactable;
    [HideInInspector, SerializeField]
    private int movementspeed;
    [HideInInspector, SerializeField]
    private int jumpheight;

    public entity(string name, bool interactable, int movementspeed, int jumpheight)
    {
        this.name = name;
        this.interactable = interactable;
        this.movementspeed = movementspeed;
        this.jumpheight = jumpheight;
    }

    [ExposeProperty]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [ExposeProperty]
    public bool Interactable
    {
        get { return interactable; }
        set { interactable = value; }
    }
    [ExposeProperty]
    public int Movementspeed
    {
        get { return movementspeed; }
        set { movementspeed = value; }
    }
    [ExposeProperty]
    public int Jumpheight
    {
        get { return jumpheight; }
        set { jumpheight = value; }
    }


}