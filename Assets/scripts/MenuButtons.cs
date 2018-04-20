using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : IO {
    [SerializeField]
    private string firstLevel;
    [SerializeField]
    private GameObject loadmenu;

public void newgame()
    {
        Playerstatus.Levelname = firstLevel;
        Playerstatus.Maxhp = 100;
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
