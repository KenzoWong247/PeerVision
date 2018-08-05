using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkVariables : MonoBehaviour {
    

    public static NetworkVariables NV;

    public static int PlayerType { get; set; }

    public static string ServerName { get; set; }

    private bool created;

    void Awake()
    {
        if (NV == null)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
            Debug.Log("Awake: " + gameObject);
        }
        else
        {
            if(NV != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
