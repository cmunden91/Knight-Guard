using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Debug.Log("Weapon Collison!");
            Fighter fight = collision.transform.GetComponent<Fighter>();
            if (fight.IsHostile == true)
            {

                fight.Currenthp = fight.Currenthp - 20;
            }
        }
    }       
}
