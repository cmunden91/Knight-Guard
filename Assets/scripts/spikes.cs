using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : fighter
{
    public void OnCollisionEnter2D(Collision2D collision)
    {

        collision.transform.GetComponent<player>().takedamage(damageofattack, forceofattack);
    }
}

