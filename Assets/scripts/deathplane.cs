using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathplane : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.GetComponent<fighter>().Currenthp = 0;
    }

}
