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
        SceneManager.LoadScene(firstLevel);
        Playerstatus.Currentdata = new SaveData(100, "HollowedForest", null);
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
