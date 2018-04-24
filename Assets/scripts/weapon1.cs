using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Fighter fight = collision.transform.GetComponent<Fighter>();
            try
            {
                if (fight.IsHostile == true)
                {

                    fight.Currenthp = fight.Currenthp - 20;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }       
}
