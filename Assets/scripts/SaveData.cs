using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {
    private int slotNumber;
    private int maxHP;
    private string scene;
    private Transform lastCheckpoint;

    public SaveData(int slotNumber, int MaxHP, string scene, Transform lastCheckpoint)
    {
        this.slotNumber = slotNumber;
        this.maxHP = MaxHP;
        this.scene = scene;
        this.lastCheckpoint = lastCheckpoint;
    }
    public int SlotNumber
    {
        get
        {
            return slotNumber;
        }
        set
        {
            slotNumber = value;
        }
    }
    public int MaxHP
    {
        get
        {
            return maxHP;
        }
        set
        {
            maxHP = value;
        }
    }
    public string Scene
    {
        get
        {
            return scene;
        }
        set
        {
            scene = value;
        }
    }


}
