using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : fighter {
    [SerializeField]
    HUD hud;

    // Use this for initialization
    void Start () {
        hud.playerbaractive(this);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
