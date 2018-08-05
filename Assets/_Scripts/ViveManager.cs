using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveManager : MonoBehaviour {


    public GameObject head;
    public GameObject rightHand;
    public GameObject leftHand;

    public static ViveManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void onDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
}
