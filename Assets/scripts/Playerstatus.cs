﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Playerstatus  {

    private static SaveData currentdata = null;

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
