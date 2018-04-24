using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    [SerializeField]
    bool active = false;
    [SerializeField] Sprite bluefire;
    [SerializeField] Sprite normalfire;
    [SerializeField] RuntimeAnimatorController bluefireanimation;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player playercollision = collision.transform.GetComponent<Player>();
        if (playercollision != null)
        {
            active = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = bluefire;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = bluefireanimation;
            playercollision.Spawnpoint = gameObject.transform;
        }
        
    }
}
