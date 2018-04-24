using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour {
    [SerializeField]
    Text[] locationFields;
    [SerializeField]
    Text[] healthFields;
    SaveData[] data;
    IO io;
    public void Awake()
    {
        io = new IO((Application.persistentDataPath + "knightguard.dat"));
    }
    private void OnEnable()
    {
        writemenu();
    }
    public void load(int slot)
    {
        if (data[slot] != null)
        {
            io.Load(slot);
        }
    }
    public void save(int slot)
    {
        io.Save(slot);
        writemenu();
    }
    private void writemenu()
    {
        data = io.Read();
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] != null)
            {
                locationFields[i].text = data[i].Scene;
                healthFields[i].text = "" + data[i].MaxHP;
            }
        }
    }
}
