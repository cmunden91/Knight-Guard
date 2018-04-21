using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpotion : MonoBehaviour {
    [SerializeField]
    int healamount;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<player>() != null)
        {
            collision.transform.GetComponent<player>().Currenthp += healamount;
            Destroy(gameObject);
        }
    }
}
