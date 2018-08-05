using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonNetworkManager : Photon.MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform professorSpawnPoint;
    [SerializeField] private Transform[] studentSpawnPoints;

    private int maxSpawnpoints;
    private int numberOfPlayers;
    private int playerType;
    
    // Use this for initialization
    void Start()
    {
        Debug.Log("Network Manager Initialized");
        //MOVED TO JOIN GAME SCRIPT
        string version = "Version 0.1";
        PhotonNetwork.ConnectUsingSettings(version);
        numberOfPlayers = 0;
        maxSpawnpoints = studentSpawnPoints.Length;
        JoinRoom();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //MOVED TO JOIN GAME SCRIPT
    public virtual void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
    }

   public void JoinRoom()
    {
        playerType = PlayerPrefs.GetInt("Type");
        Debug.Log("Player Type " + playerType);
        if (playerType == 0)
        {
            string serverName = PlayerPrefs.GetString("ServerName");
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 6;
            PhotonNetwork.CreateRoom(serverName, roomOptions, null);
            Debug.Log("Created Room: " + serverName);
        }
        else
        {
            string serverName = PlayerPrefs.GetString("JoinServerName");
            PhotonNetwork.JoinRoom(serverName);
            Debug.Log("Joined Room " + serverName);
        }
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("We have now joined the lobby");        
    }

    public virtual void OnJoinedRoom()
    {
        if(playerType == 0)
        {
            PhotonNetwork.Instantiate(player.name, professorSpawnPoint.position, professorSpawnPoint.rotation, 0);
        }
        else
        {
            int numberOfPlayers = PhotonNetwork.playerList.Length - 1;
            if (numberOfPlayers > 2)
                numberOfPlayers = numberOfPlayers % maxSpawnpoints;
            int spawnpoint = numberOfPlayers - 1;
            PhotonNetwork.Instantiate(player.name, studentSpawnPoints[spawnpoint].position, studentSpawnPoints[spawnpoint].rotation, 0);
        }
    }
  
    
}
