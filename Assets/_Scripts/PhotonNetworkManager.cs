using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNetworkManager : Photon.MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] spawnPoints;

    private int maxSpawnpoints;
    private int numberOfPlayers;



    // Use this for initialization
    void Start()
    {
        string version = "Version 0.1";
        PhotonNetwork.ConnectUsingSettings(version);
        numberOfPlayers = 0;
        maxSpawnpoints = spawnPoints.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("We have now joined the lobby");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;

        string roomName = 

        PhotonNetwork.JoinOrCreateRoom("RoomName", roomOptions, null);
        
    }

    public virtual void OnJoinedRoom()
    {
        int numberOfPlayers = PhotonNetwork.playerList.Length;
        if (numberOfPlayers > 2)
            numberOfPlayers = numberOfPlayers % 2;
        int spawnpoint = numberOfPlayers - 1;

        Debug.Log("Spawnpoint: " + spawnpoint);
        PhotonNetwork.Instantiate(player.name, spawnPoints[spawnpoint].position, spawnPoints[spawnpoint].rotation, 0);
    }
    
}
