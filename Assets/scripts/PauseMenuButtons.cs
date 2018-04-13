using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour {
    [SerializeField]
    private GameObject pausemenu;
    [SerializeField]
    private string mainmenu;
    [SerializeField]
    private GameObject loadmenu;
    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void load()
    {
        loadmenu.SetActive(true);
    }
    public void options()
    {

    }
    public void quit()
    {
        SceneManager.LoadScene(mainmenu);
        Time.timeScale = 1;
    }
}
