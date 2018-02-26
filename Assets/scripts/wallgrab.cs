using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallgrab : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

 /*   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<player>() != null)
        {
            playercontroller controller = col.GetComponent<playercontroller>();
            controller. Wallgrab(true);
            //collider.sharedMaterial = wallclimb;
        }
    } */
  /*  void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<player>() != null)
        {
            playercontroller controller = col.GetComponent<playercontroller>();
            controller.Wallgrab(false);
        }
    } */
} 
