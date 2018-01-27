using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class hp : ExposableMonobehaviour
{

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
    [HideInInspector, SerializeField]
    private GameObject hppip;


    /*public void drawhp()
    {

;        int currenthp = play.Currenthp;
        for(int i = 0; i < (currenthp/5); i++)
        {
            GameObject currenthppip = Instantiate(hppip, new Vector3(playerhpx, playerhpy, 0), Quaternion.identity);
            currenthppip.transform.SetParent(hpcontainer.transform);
        } 
        
    } */
    public void maxhp(player play)
    {
       int maxhp = play.Maxhp; 
    }
    // Use this for initialization
    void Start()
    {
        //hppip = (GameObject)Resources.Load("hppip", typeof(Object));
        hpblocks = 0;
        maxhpblocks = 0;
        hpbackcontainer = gameObject.transform.GetChild(0).gameObject;
        hpcontainer = gameObject.transform.GetChild(1).gameObject;
        //play = GameObject.FindGameObjectWithTag("player").GetComponent<player>();
        GameObject currenthppip = Instantiate(hppip, new Vector3(-401.2f, 199.2f, 0), Quaternion.identity);
        currenthppip.transform.SetParent(hpcontainer.transform);
    }
    [ExposeProperty]
    public float Playerhpy
    {
        get { return playerhpy; }
        set {
            playerhpy = value;
            
            }
    }
    [ExposeProperty]
    public float Playerhpx
    {
        get { return playerhpy;  }
        set {
            playerhpy = value;
           
        }
    }

    [ExposeProperty]
    public GameObject HpPip
    {
        get { return hppip; }
        set { hppip = value; }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
