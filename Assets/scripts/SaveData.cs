using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData : MonoBehaviour {
    private int maxHP;
    private string scene;
    private Transform lastCheckpoint;
  
    public SaveData(int MaxHP, string scene, Transform lastCheckpoint)
    {
        this.maxHP = MaxHP;
        this.scene = scene;
        this.lastCheckpoint = lastCheckpoint;
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
