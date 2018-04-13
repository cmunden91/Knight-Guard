using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class IO : MonoBehaviour {
   private string path = Application.persistentDataPath + "knightguard.dat";
   private BinaryFormatter bf = new BinaryFormatter();
    private SaveData[] data;
    public SaveData[] Read()
    {
        try
        {
            FileStream file = File.Open(path, FileMode.Open);
            data = (SaveData[])bf.Deserialize(file);
            file.Close();
            
        }
        catch(IOException)
        {
            FileStream file = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
            SaveData[] blankdata = new SaveData[3];
            bf.Serialize(file, blankdata);
            file.Close();
            Read();
        }
        return data;
    }

    public void Load(int slot)
    {
        Playerstatus.Currentdata = data[slot];
        EditorSceneManager.LoadScene(data[slot].Scene);
    }

    public void Save(int slot)
    {
        data[slot] = Playerstatus.Currentdata;
        FileStream file = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
    }
}
