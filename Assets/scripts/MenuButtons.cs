using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    [SerializeField]
    private string firstLevel;

public void newgame()
    {
        SceneManager.LoadScene(firstLevel);
        Playerstatus.Currentdata = new SaveData(-1, 100, "FirstLevel", null);
    }
    public void loadgame()
    {

    }
    public void options()
    {

    }

    public void quit()
    {
        Application.Quit();
    }


}
