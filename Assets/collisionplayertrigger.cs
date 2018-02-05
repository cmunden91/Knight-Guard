using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionplayertrigger : ExposableMonobehaviour {
    [HideInInspector, SerializeField]
    private BoxCollider2D ground;
    [HideInInspector, SerializeField]
    private GameObject player;

    // Use this for initialization
    void Start () {
        ground = GetComponent<BoxCollider2D>();
        Debug.Log(ground);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [ExposeProperty]
    public GameObject Player
    {
        get { return player; }
        set { value = player; }
    }
    void OnTriggerEnter(Collider ground)
    {
        Debug.Log("Test");

    }
}
