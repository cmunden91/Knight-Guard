using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallgrab : MonoBehaviour {
	[SerializeField]
	private BoxCollider2D collider;
    [SerializeField]
    private PhysicsMaterial2D wallclimb;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col) {
        if (col.GetComponent<player>() != null)
        {
            col.GetComponent<playercontroller>().Isgrounded = true;
            collider.sharedMaterial = wallclimb; 
        }
	}

}
