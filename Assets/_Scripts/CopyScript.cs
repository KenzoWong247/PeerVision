using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            transform.position = ViveManager.Instance.head.transform.position;
            transform.rotation = ViveManager.Instance.head.transform.rotation;
        }
	}
}
