using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class IO : ScriptableObject
{
    private string path;
    private SaveData[] data;

    public IO(string path)
    {
        this.path = path;
    }

    public SaveData[] Read()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file;
            object data = bf.Deserialize(file = File.Open(path, FileMode.Open));
            file.Dispose();
           

        }
        catch (IOException)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
            SaveData[] blankdata = new SaveData[3];
            bf.Serialize(file, blankdata);
            file.Dispose();
            Read();
        }
        for(int i = 0; i < data.Length;i++)
        {
            Debug.Log(data[i].Scene + ", " + data[i].MaxHP);
        }
        return data;
    }

    public void Load(int slot)
    {
        Playerstatus.Currentdata = data[slot];
        //EditorSceneManager.LoadScene(data[slot].Scene);
    }

    public void Save(int slot)
    {
        BinaryFormatter bf = new BinaryFormatter();
        data[slot] = Playerstatus.Currentdata;
        FileStream file = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
        bf.Serialize(file, data);
        file.Close();
    }
}
