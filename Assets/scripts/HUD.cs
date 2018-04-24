using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {
    [SerializeField]
    private GameObject hpbar;
    [SerializeField]
    private GameObject hpbarback;
    [SerializeField]
    private int hpsizemultiplyer;
    private RectTransform hpbarbacktransform;
    private RectTransform hpbartransform;
    private float defaultbackx;
    private float defaultbarx;
    private Fighter player;
    private float backinticaloffset;
    private float barinticaloffset;

    public void Start()
    {
       hpbarbacktransform = hpbarback.GetComponent<RectTransform>();
       hpbartransform = hpbar.GetComponent<RectTransform>();
		defaultbackx = hpbarbacktransform.sizeDelta.x;
		defaultbarx = hpbartransform.sizeDelta.x;
        backinticaloffset = hpbarbacktransform.anchoredPosition.x;
        barinticaloffset = hpbartransform.anchoredPosition.x;
    }

    public void playerbaractive(Fighter player)
    {
        this.player = player;
        playerbarupdate();
        hpbarback.SetActive(true);
        hpbar.SetActive(true);
        Debug.Log(hpbar.GetType());

    }
    public void playerbarupdate()
    {
		hpbarbacktransform.sizeDelta = new Vector3(defaultbackx + (player.Maxhp * hpsizemultiplyer), hpbarbacktransform.sizeDelta.y, hpbarbacktransform.localScale.z);
		hpbartransform.sizeDelta = new Vector3(defaultbarx + (player.Currenthp * hpsizemultiplyer), hpbartransform.sizeDelta.y, hpbartransform.localScale.z);
        hpbarbacktransform.anchoredPosition = new Vector2((backinticaloffset + (player.Maxhp * hpsizemultiplyer))/2, hpbarbacktransform.anchoredPosition.y);
        hpbartransform.anchoredPosition = new Vector2((barinticaloffset + (player.Currenthp * hpsizemultiplyer))/2, hpbartransform.anchoredPosition.y);
    }
}
