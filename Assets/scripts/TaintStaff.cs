using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaintStaff : fighter {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<player>().takedamage(damageofattack, forceofattack);
    }


}
