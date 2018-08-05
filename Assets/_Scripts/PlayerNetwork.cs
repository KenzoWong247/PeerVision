using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {
    
    [SerializeField] private MonoBehaviour[] playerControlScripts;

    [SerializeField] private GameObject playerEars;

    [SerializeField] private GameObject playerEyes;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        Initialize();
    }
    
    private void Initialize()
    {
        if (!photonView.isMine)
        {
            playerEars.SetActive(false);
            playerEyes.SetActive(false);
            foreach(MonoBehaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }
    }
}
