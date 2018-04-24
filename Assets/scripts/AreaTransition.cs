using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTransition : MonoBehaviour {
    [SerializeField]
    private string level;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player playercol = collision.GetComponent<Player>();
        if(playercol != null)
        {
            SceneManager.LoadScene(level);
            Playerstatus.Currentdata.Scene = level;
        }
    }

}
