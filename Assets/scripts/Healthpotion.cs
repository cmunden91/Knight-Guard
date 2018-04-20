using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpotion : MonoBehaviour {
    [SerializeField]
    int healamount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<player>().Currenthp+=healamount;   
            Destroy(gameObject);
    }
}
