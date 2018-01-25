using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class hp : ExposableMonobehaviour {
    [HideInInspector, SerializeField]
    private int hpblocks;
    [HideInInspector, SerializeField]
    private int maxhpblocks;
    [HideInInspector, SerializeField]
    private GameObject hpcontainer;
    [HideInInspector, SerializeField]
    private GameObject hpbackcontainer;
    [HideInInspector, SerializeField]
    private float playerhpx;
    [HideInInspector, SerializeField]
    private float playerhpy;
    [HideInInspector, SerializeField]
    private player play;
    private GameObject hppip;


    public void drawhp()
    {

;        int currenthp = play.Currenthp;
        for(int i = 0; i < (currenthp/5); i++)
        {
            GameObject currenthppip = Instantiate(hppip);
        } 
        
    } 
    public void maxhp(player play)
    {
       int maxhp = play.Maxhp; 
    } 
	// Use this for initialization
	void Start () {
        hppip = Resources.Load("hppip", typeof(GameObject));
        hpblocks = 0;
        maxhpblocks = 0;
        hpbackcontainer = gameObject.transform.GetChild(0).gameObject;
        hpcontainer = gameObject.transform.GetChild(1).gameObject;
        play = GameObject.FindGameObjectWithTag("player").GetComponent<player>();
    }
    public float Playerhpy
    {
        get { return playerhpy; }
        set {
            playerhpy = value;
            drawhp();
            }
    }
    public float Playerhpx
    {
        get { return playerhpy;  }
        set {
            playerhpy = value;
            drawhp();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
