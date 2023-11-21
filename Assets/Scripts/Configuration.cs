using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Configuration
{
    private static Configuration instance;

    public bool initialInput = false;
    public float latency = 3;

    public static Configuration Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Configuration();
            }
            return instance;
        }
    }
}
