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
        SaveData currentdata = Playerstatus.Currentdata;
        currentdata.MaxHP = 100;
        currentdata.Scene = "HollowedForest";
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
