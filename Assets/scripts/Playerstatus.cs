using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Playerstatus {

    private static string levelname;
    private static int maxhp;
    private static Transform checkpoint;

    public static string Levelname
    {
        get
        {
            return levelname;
        }
        set
        {
            levelname = value;
        }
    }
    public static int Maxhp
    {
        get
        {
            return maxhp;
        }
        set
        {
            maxhp = value;
        }
    }
    public static Transform Checkpoint
    {
        get
        {
            return checkpoint;
        }
        set
        {
            checkpoint = value;
        }
    }
}
