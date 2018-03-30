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
