using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkVariables : MonoBehaviour {
   
    public void SetServerName(Text text)
    {
        PlayerPrefs.DeleteKey("ServerName");
        PlayerPrefs.SetString("ServerName", text.text);
        Save();
    }

    public void SetPlayerType(int type)
    {
        PlayerPrefs.DeleteKey("PlayerType");
        PlayerPrefs.SetInt("PlayerType", type);
        Debug.Log("Set Player Type to " + type);
        Save();
    }

    public void JoinServerName(RoomListItem roomListItem)
    {
        PlayerPrefs.DeleteKey("JoinServerName");
        string name = roomListItem.GetRoomName();
        PlayerPrefs.SetString("JoinServerName", name);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.Save();
    }
    
}
