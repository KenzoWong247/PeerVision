using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void setPlayerType(int type)
    {
        NetworkVariables.PlayerType = type;
        Debug.Log("Set server type as " + type);
    }

    public void setServerName(Text Text)
    {
        string name = Text.text;
        NetworkVariables.ServerName = name;
        Debug.Log("Set server name as " + name);
    }

    public void setServerName(RoomListItem serverListItem)
    {
        string name = serverListItem.GetRoomName();
        NetworkVariables.ServerName = name;

        Debug.Log("Set server name as " + name);
    }
}
