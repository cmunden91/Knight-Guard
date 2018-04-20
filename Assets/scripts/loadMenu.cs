using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadMenu : IO {
    [SerializeField]
    Text[] locationFields;
    [SerializeField]
    Text[] healthFields;
    SaveData[] data;
    IO io;
    public void Awake()
    {
        string path = Application.persistentDataPath + "knightguard.dat";
        base.init(path);
       
    }
    private void OnEnable()
    {
        writemenu();
    }
    public void load(int slot)
    {
        if (data[slot] != null)
        {
            base.Load(slot);
        }
    }
    public void save(int slot)
    {
        base.Save(slot);
        writemenu();
    }
    private void writemenu()
    {
        data = base.Read();
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
