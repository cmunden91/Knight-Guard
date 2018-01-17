using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : fighter {
    private static string name = "Player";
    private static bool interactable = false;
    private static int defaulthealth = 100;
    private static bool hostile = false;
    public player() : base(name, interactable, defaulthealth, defaulthealth, hostile)
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
