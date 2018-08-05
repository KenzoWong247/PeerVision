using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour {


    [SerializeField]
    private Text RoomNameText;
   

    RoomInfo roomInfo;

    public void Setup(RoomInfo info)
    {
        roomInfo = info;
        
        RoomNameText.text = roomInfo.Name + " (" + info.PlayerCount + "/" + info.MaxPlayers + ") (Click to Join)";
    }

    public string GetRoomName()
    {
        return roomInfo.Name;
    }
}
