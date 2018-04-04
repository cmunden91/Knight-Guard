using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testblock : fighter
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        collision.transform.GetComponent<player>().takedamage(damageofattack, forceofattack);
    }
}
