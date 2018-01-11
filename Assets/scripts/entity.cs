using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class entity : ExposableMonobehaviour
{
    [HideInInspector, SerializeField]
    private string name;
    [HideInInspector, SerializeField]
    private bool interactable;

    public entity(string name, bool interactable)
    {
        this.name = name;
        this.interactable = interactable;
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
}