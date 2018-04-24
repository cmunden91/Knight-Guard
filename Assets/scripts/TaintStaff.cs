﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaintStaff : Fighter
{
    [SerializeField]
    GameObject drop1;
    [SerializeField]
    GameObject drop2;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().takedamage(damageofattack, forceofattack);
    }

    public override void death()
    {
        int drop = Random.Range(1, 100);
        if (drop <= 20)
        {
            Instantiate(drop1, new Vector3(0, 0, 0), gameObject.transform.rotation, gameObject.transform);
        }
        if (drop > 20)
        {
            Instantiate(drop2, gameObject.transform.position, gameObject.transform.rotation);
        }
        base.death();
    }


}
