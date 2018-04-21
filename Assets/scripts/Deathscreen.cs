using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour {


    public void retry()
    {
        SceneManager.LoadScene(Playerstatus.Currentdata.Scene);
        Time.timeScale = 1;
        
    }
    public void quit()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
