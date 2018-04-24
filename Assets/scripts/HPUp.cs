using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : MonoBehaviour {
    /*
     * Simple script for HPUp. will alter the players Maximun HP
     */

    [SerializeField]
    int MaxHPAmount;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>() != null) //If the object collided is a player..
        {
            collision.transform.GetComponent<Player>().Maxhp += MaxHPAmount;
            collision.transform.GetComponent<Player>().Currenthp += MaxHPAmount;
            Destroy(gameObject); //Picking up the potion will cause it to destroy itself.
        }
    }
}
