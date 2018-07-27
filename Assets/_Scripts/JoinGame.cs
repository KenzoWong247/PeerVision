using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {

    [SerializeField]
    private Text status;

    [SerializeField]
    private GameObject roomListItemPrefab;

    [SerializeField]
    private Transform roomListParent;

    List<GameObject> roomList = new List<GameObject>();

    private NetworkManager networkManager;

	// Use this for initialization
	void Start () {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();
	}

    public void RefreshRoomList()
    {
        ClearRoomList();
        networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        status.text = "Loading...";
        Debug.Log("Refreshing");
    }

    public void OnMatchList(bool succes, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        if(matchList == null)
        {
            status.text = "Could not retrieve server list.";
            return;
        }
        status.text = "";
        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject roomItem = Instantiate(roomListItemPrefab);
            roomItem.transform.SetParent(roomListParent);

            ServerListItem roomListItem = roomItem.GetComponent<ServerListItem>();
            if(roomListItem != null)
            {
                roomListItem.Setup(match, ConnectToGame);
            }


            roomList.Add(roomItem);
        }
        
        if(roomList.Count == 0)
        {
            status.text = "Could not find any servers.";
        }

    }

    void ClearRoomList()
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }
	
    public void ConnectToGame(MatchInfoSnapshot match)
    {
        Debug.Log("Joining Game: " + match.name);
        networkManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, OnJoinMatch);
        ClearRoomList();
    }

    private void OnJoinMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Able to join match");

            MatchInfo hostInfo = matchInfo;
            networkManager.StartClient(hostInfo);
        }
        else
        {
            Debug.Log("Failed to join match");
            status.text = "Failed to join match";
        }
    }
}
