using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : fighter {
    [SerializeField]
    private HUD hud;

    // Use this for initialization
    void Start () {
        hud.playerbaractive(this);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public new void takedamage(int amount, float force)
    {
        if (base.takedamage(amount, force) == true)
        {
            hud.playerbarupdate();
        }
    }


}
