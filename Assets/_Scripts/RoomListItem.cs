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

        RoomNameText.text = info.Name + " (" + info.PlayerCount + "/" + info.MaxPlayers + ") (Click to Join)";
    }

}
