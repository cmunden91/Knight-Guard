using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Fighter
{
    public void OnCollisionEnter2D(Collision2D collision)
    {

        collision.transform.GetComponent<Player>().takedamage(damageofattack, forceofattack);
    }
}

