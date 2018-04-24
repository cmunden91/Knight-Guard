using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitbutton : MonoBehaviour {
    [SerializeField]
    private GameObject panel;

    public void close()
    {
        panel.SetActive(false); 
    }
}
