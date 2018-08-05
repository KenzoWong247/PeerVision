using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkVariables : MonoBehaviour {

    public void SetServerName(Text text)
    {
        PlayerPrefs.SetString("ServerName", text.text);
    }

    public void SetPlayerType(int type)
    {
        PlayerPrefs.SetInt("PlayerType", type);
        Debug.Log("Set Player Type to " + type);
    }

    public void JoinServerName(RoomListItem roomListItem)
    {
        string name = roomListItem.GetRoomName();
        PlayerPrefs.SetString("JoinServerName", name);
    }
    
}
