using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonNetworkManager : Photon.MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject Rig;
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
        int playerType = NetworkVariables.PlayerType;
        Debug.Log("Retrieved player Type " + playerType);

        string serverName = NetworkVariables.ServerName;
        Debug.Log("Retrieved server name " + serverName);
        if (playerType == 0)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 6;
            PhotonNetwork.JoinOrCreateRoom(serverName, roomOptions, null);
            Debug.Log("Created Room: " + serverName);
        }
        else
        {
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

            Rig.transform.position = studentSpawnPoints[spawnpoint].position;
            Rig.transform.rotation = studentSpawnPoints[spawnpoint].rotation;
            ViveManager.Instance.head.transform.position = studentSpawnPoints[spawnpoint].position;
            ViveManager.Instance.head.transform.rotation = studentSpawnPoints[spawnpoint].rotation;
            PhotonNetwork.Instantiate(player.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);
        }
    }
  
    
}
