using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpotion : MonoBehaviour {
    /*
     * Simple script for healing potions. Healing on collision.
     */
     
    [SerializeField]
    int healamount;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>() != null) //If the object collided is a player
        {
            collision.transform.GetComponent<Player>().Currenthp += healamount;
            Destroy(gameObject); //Picking up the potion will destroy it in the process
        }
    }
}
