using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class IO : MonoBehaviour
{
    private string path;
    private SaveData[] data;

    public void init(string path)
    {
        this.path = path;
        data = new SaveData[3];
    }

    public SaveData[] Read()
    {
        
        if (System.IO.File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            object data = bf.Deserialize(file);
            file.Close();
            data = (SaveData[])data;

        }
        else
        {
            createFile();
            Read();
        }
        return data;
    }

    public void createFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        SaveData blankdata = new SaveData();
        blankdata.LastCheckpoint = null;
        blankdata.MaxHP = 100;
        blankdata.Scene = "";
        SaveData[] blanksave = { blankdata, blankdata, blankdata };
        bf.Serialize(file, blanksave);
        file.Close();
    }

    public void Load(int slot)
    {
        Playerstatus.Levelname = data[slot].Scene;
        Playerstatus.Maxhp = data[slot].MaxHP;
        Playerstatus.Checkpoint = data[slot].LastCheckpoint;
        EditorSceneManager.LoadScene(Playerstatus.Levelname);
    }

    public void Save(int slot)
    {
        Debug.Log(data[slot]);
        BinaryFormatter bf = new BinaryFormatter();
        data[slot].Scene = Playerstatus.Levelname;
        data[slot].MaxHP = Playerstatus.Maxhp;
        data[slot].LastCheckpoint = Playerstatus.Checkpoint;
        FileStream file = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
        bf.Serialize(file, data);
        file.Close();
    }

    [Serializable]
    public class SaveData
    {
        int maxHP;
        string scene;
        Transform lastCheckpoint;

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
        public Transform LastCheckpoint
        {
            get
            {
                return lastCheckpoint;
            }
            set
            {
                lastCheckpoint = value;
            }
        }
    }
}
