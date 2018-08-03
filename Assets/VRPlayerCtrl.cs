using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerCtrl : NetworkTransform {

    public GameObject rightContSource;

    public GameObject leftContSource;

    public GameObject headObjSource;


    //prefabs to assign head, left controller, and right controller
    public GameObject vrHeadObjPrefab;
    public GameObject vrLeftCtrlPrefab;
    public GameObject vrRightCtrlPrefab;

    GameObject vrHeadObj;
    GameObject vrLeftCtrl;
    GameObject vrRightCtrl;

    void Start()
    {

        Debug.Log("Start of the vr player");

        if (isLocalPlayer)
        {
            //instantiate prefabs
            CmdInstantiteHeadAndController();
            //disabled conroller meshes at VR player side so it cannont be view by him
            vrLeftCtrl.GetComponent<MeshRenderer>().enabled = false;
            vrRightCtrl.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    //Instantiate on start head and vr controller object so that it can be view by normal players
    void CmdInstantiteHeadAndController()
    {
        Debug.Log("instantiateing the controller and head object");
        vrHeadObj = (GameObject)Instantiate(vrHeadObjPrefab);
        vrLeftCtrl = (GameObject)Instantiate(vrLeftCtrlPrefab);
        vrRightCtrl = (GameObject)Instantiate(vrRightCtrlPrefab);

        // spawn the bullet on the clients
        NetworkServer.Spawn(vrHeadObj);
        NetworkServer.Spawn(vrLeftCtrl);
        NetworkServer.Spawn(vrRightCtrl);
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //sync pos on network
        CmdControllerPositionSync();
    }
    //sync position on VR controller objects so that VR player movemnts/action can be viewd by normal user
    [Command]
    public void CmdControllerPositionSync()
    {

        vrHeadObj.transform.localRotation = headObjSource.transform.localRotation;
        vrHeadObj.transform.position = headObjSource.transform.position;
        vrLeftCtrl.transform.localRotation = leftContSource.transform.localRotation;
        vrRightCtrl.transform.localRotation = rightContSource.transform.localRotation;
        vrLeftCtrl.transform.localPosition = leftContSource.transform.position;
        vrRightCtrl.transform.localPosition = rightContSource.transform.position;
    }
}
