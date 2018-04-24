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
        if (playercollision != null) //If the collided object is a player
        {
            active = true; 
            gameObject.GetComponent<SpriteRenderer>().sprite = bluefire; //changes model to blue
            gameObject.GetComponent<Animator>().runtimeAnimatorController = bluefireanimation; //changes animator for the blue fire.
            playercollision.Spawnpoint = gameObject.transform; //changed spawnpoint too the checkpoints transform.
        }
        
    }
}
