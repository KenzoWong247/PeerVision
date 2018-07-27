using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    Behaviour[] componentsToDisable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }
}
