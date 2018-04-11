using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {
    [SerializeField]
    bool active = false;
    [SerializeField] Sprite bluefire;
    [SerializeField] Sprite normalfire;

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
       player playercollision = collision.transform.GetComponent<player>();
        if (playercollision != null)
        {
            active = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = bluefire;
        }
        
    }
}
