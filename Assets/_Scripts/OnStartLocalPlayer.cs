using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartLocalPlayer : MonoBehaviour {

    [SerializeField] public Transform RigHead;
    [SerializeField] public Transform RigRightHand;
    [SerializeField] public Transform RigLeftHand;
    [SerializeField] public Transform PlayerHead;
    [SerializeField] public Transform PlayerRightHand;
    [SerializeField] public Transform PlayerLeftHand;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHead.position = RigHead.position;
        PlayerRightHand.position = RigRightHand.position;
        PlayerLeftHand.position = RigLeftHand.position;
        
	}
}
