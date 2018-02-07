using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class entity : MonoBehaviour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private bool interactable;
    [SerializeField]
    private int movementspeed;
    [SerializeField]
    private int jumpheight;

    public entity(string name, bool interactable, int movementspeed, int jumpheight)
    {
        this.name = name;
        this.interactable = interactable;
        this.movementspeed = movementspeed;
        this.jumpheight = jumpheight;
    }

    [HideInInspector]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [HideInInspector]
    public bool Interactable
    {
        get { return interactable; }
        set { interactable = value; }
    }
    [HideInInspector]
    public int Movementspeed
    {
        get { return movementspeed; }
        set { movementspeed = value; }
    }
    [HideInInspector]
    public int Jumpheight
    {
        get { return jumpheight; }
        set { jumpheight = value; }
    }


}