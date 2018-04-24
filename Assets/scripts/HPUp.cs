using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : MonoBehaviour {
    [SerializeField]
    int MaxHPAmount;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>() != null)
        {
            collision.transform.GetComponent<Player>().Maxhp += MaxHPAmount;
            collision.transform.GetComponent<Player>().Currenthp += MaxHPAmount;
            Destroy(gameObject);
        }
    }
}
