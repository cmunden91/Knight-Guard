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
    public GameObject hppip;
    public GameObject hpback;
    public GameObject hpbackbutt;
    [HideInInspector, SerializeField]
    private float spacing;
    private GameObject[] hppips;
    private GameObject[] hpbacks;

    public void drawhp()
    {
        if (Application.isPlaying == true) {
            ;        //int currenthp = play.Currenthp;
            int currenthp = 100;
            int maxhp = 100;
            if (hppips != null)
            {
                for (int i = 0; i < hppips.Length; i++)
                {
                    Destroy(hppips[i]);
                }
                hppips = null;
            }

            if (hpbacks != null)
            {
                for (int i = 0; i < hpbacks.Length; i++)
                {
                    Destroy(hpbacks[i]);
                }
                hpbacks = null;
            }

            hppips = new GameObject[(currenthp)];
            for (int i = 0; i < (currenthp); i++)
            {
                hppips[i] = Instantiate(hppip, new Vector3((playerhpx + (i * spacing)), playerhpy, 0), Quaternion.identity);
                hppips[i].transform.SetParent(hpcontainer.transform);
                RectTransform rt = hppips[i].GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((playerhpx + (i * spacing)), playerhpy);
                
            }

            for (int i = 0; i < 100; i++)
            {
                if (i == 0 | i == 100 - 1)
                {
                    hpbacks[i] = Instantiate(hpback, new Vector3((playerhpx + (i * spacing)), playerhpy, 0), Quaternion.identity);
                }
                else
                {
                    hpbacks[i] = Instantiate(hpback, new Vector3((playerhpx + (i * spacing)), playerhpy, 0), Quaternion.identity);
                }
                hpbacks[i].transform.SetParent(hpbackcontainer.transform);
                RectTransform rt = hpbacks[i].GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((playerhpx + (i * spacing)), playerhpy);
            }

        }
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
        drawhp();
    }
    [ExposeProperty]
    public float Playerhpy
    {
        get { return playerhpy; }
        set {
            playerhpy = value;
            drawhp();
            }
    }
    [ExposeProperty]
    public float Playerhpx
    {
        get { return playerhpx;  }
        set {
            playerhpx = value;
            drawhp();
        }
    }
    [ExposeProperty]
    public float Spacing
    {
        get { return spacing; }
        set
        {
            spacing = value;
            drawhp();
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
