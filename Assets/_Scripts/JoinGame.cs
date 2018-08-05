using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGame : Photon.MonoBehaviour {

    [SerializeField] private Text status;
    [SerializeField] private GameObject RoomListItemPrefab;
    [SerializeField] private Transform RoomListParent;

    List<GameObject> roomList = new List<GameObject>();
    RoomInfo[] list;

    // Use this for initialization
    void Start () {
        string version = "Version 0.1";
        PhotonNetwork.ConnectUsingSettings(version);
        //AUTO JOIN ENABLED
        //PhotonNetwork.JoinLobby();
        //Debug.Log("Joined Lobby");
        RefreshRoomList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
    }

    public void RefreshRoomList()
    {
        ClearRoomList();
        status.text = "Loading...";
        OnMatchList();
    }

    public virtual void OnReceivedRoomListUpdate()
    {
        list = PhotonNetwork.GetRoomList();
        Debug.Log("Retrieving Room List");
    }

    public void OnMatchList()
    {
        status.text = "";


        if (list != null)
        {
            Debug.Log("Room List Size: " + list.Length);
            foreach (RoomInfo room in list)
            {
                Debug.Log("Found: " + room.Name);
                GameObject _roomListItemObject = Instantiate(RoomListItemPrefab);
                _roomListItemObject.transform.SetParent(RoomListParent);

                RoomListItem _roomListItem = _roomListItemObject.GetComponent<RoomListItem>();
                if (_roomListItem != null)
                {
                    _roomListItem.Setup(room);
                }

                roomList.Add(_roomListItemObject);
            }
        }
        else
        {
            status.text = "Room list could not be found";
        }
        if (roomList == null)
        {
            status.text = "Could not get room list.";
            Debug.Log("Could not get room list");
            return;
        }

        if (roomList.Count == 0)
        {
            status.text = "No rooms found";
        }
    }

    private void ClearRoomList()
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }




}
