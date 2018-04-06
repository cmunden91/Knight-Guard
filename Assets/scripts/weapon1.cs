using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1 : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Debug.Log("Weapon Collison!");
            fighter fight = collision.transform.GetComponent<fighter>();
            if (fight.IsHostile == true)
            {

                fight.Currenthp = fight.Currenthp - 20;
            }
        }
    }
}
