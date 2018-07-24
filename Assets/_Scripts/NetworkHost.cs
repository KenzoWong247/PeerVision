using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkHost : MonoBehaviour {

    [SerializeField]
    private uint roomSize = 6;

    private string roomName;

    private NetworkManager networkManager;

	// Use this for initialization
	void Start () {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetRoomName(string RoomName)
    {
        roomName = RoomName;
    }

    public void CreateRoom()
    {
        if(roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName + " with capacity of " + roomSize);
            //MatchName, Match Size, Discoverable, Password, Callback Function
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }
}
