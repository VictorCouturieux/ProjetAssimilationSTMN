using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour {
    [SerializeField] private RoomLayoutGroup _roomLayoutGroup;
    private RoomLayoutGroup RoomLayoutGroup {
        get { return _roomLayoutGroup; }
    }

    /**
     * methode d'exception "can't connect to room"
     */
    public void OnClickJoinRoom(string roomName) {
        if (PhotonNetwork.JoinRoom(roomName)) {
            Debug.Log("Clique sur le bouton");
        }
        else {
            print("Join room failed.");
        }
    }
}