using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class ServerListItem : MonoBehaviour {

    public delegate void JoinGameDelegate(MatchInfoSnapshot match);

    public JoinGameDelegate joinGameCallback;

    [SerializeField]
    private Text roomNameText;

    private MatchInfoSnapshot match;

    public void Setup(MatchInfoSnapshot _match, JoinGameDelegate _joinGameCallback)
    {
        match = _match;

        roomNameText.text = "\t" + match.name + " (" + match.currentSize + "/" + match.maxSize + ") (Click to Join)";
        joinGameCallback = _joinGameCallback;

    }

    public void JoinGame()
    {
        joinGameCallback.Invoke(match);
    }
    
}
