using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitbutton : MonoBehaviour {
    [SerializeField]
    private GameObject panel;

    public void close()
    {
        panel.SetActive(false); 
    }
}
