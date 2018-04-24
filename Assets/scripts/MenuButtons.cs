using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    [SerializeField]
    private string firstLevel;
    [SerializeField]
    private GameObject loadmenu;

public void newgame()
    {
        Playerstatus.Currentdata.MaxHP = 100;
        Playerstatus.Currentdata.Scene = firstLevel;
        Playerstatus.Currentdata.LastCheckpoint = null;
        SceneManager.LoadScene(firstLevel);
    }
    public void loadgame()
    {
        loadmenu.SetActive(true);
    }
    public void options()
    {

    }

    public void quit()
    {
        Application.Quit();
    }


}
