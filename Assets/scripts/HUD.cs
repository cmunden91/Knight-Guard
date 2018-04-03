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
    private fighter player;

    public void Start()
    {
        RectTransform hpbarbacktransform = hpbarback.GetComponent<RectTransform>();
        RectTransform hpbartransform = hpbar.GetComponent<RectTransform>();
        defaultbackx = hpbarbacktransform.sizeDelta.x;
        defaultbarx = hpbartransform.sizeDelta.x;
    }

    public void playerbaractive(fighter player)
    {
        this.player = player;
        playerbarupdate();
        hpbarback.SetActive(true);
        hpbar.SetActive(true);
        Debug.Log(hpbar.GetType());

    }
    public void playerbarupdate()
    {
        hpbarbacktransform.sizeDelta = new Vector2(defaultbackx + (player.Maxhp * hpsizemultiplyer), hpbarbacktransform.sizeDelta.y);
        hpbartransform.sizeDelta = new Vector2(defaultbarx + (player.Currenthp * hpsizemultiplyer), hpbartransform.sizeDelta.y);
    }
}
