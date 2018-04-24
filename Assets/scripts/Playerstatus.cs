using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Playerstatus  {
    /**
     * this script tracks all of the player data that will carry over from one scene ro another.
     */
     
    private static SaveData currentdata = new SaveData(100, "", null);

    public static SaveData Currentdata
    {
        get
        {
            return currentdata;
        }
        set
        {
            currentdata = value;
        }
    }

}

