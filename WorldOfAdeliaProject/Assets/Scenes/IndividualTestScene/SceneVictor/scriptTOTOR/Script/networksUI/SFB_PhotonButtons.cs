using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by COUTURIEUX VICTOR in collaboration with BUCHER MORGAN
/// used by button to create or join a room 
/// </summary>
public class SFB_PhotonButtons : MonoBehaviour {
    /// <summary>
    /// InputField instance
    /// used to get the room name
    /// </summary>
    public InputField createRoomInput, joinRoomInput;

    // Start is called before the first frame update (not used)
    void Start() {
    }

    /// <summary>
    /// Create room
    /// </summary>
    public void onClickCreateRoom() {
        GameManager.instance.NetworkManager.createNewRoom();
    }

    /// <summary>
    /// Join Room
    /// </summary>
    public void onClickJoinRoom() {
        GameManager.instance.NetworkManager.joinOrCreateRoom();
    }

    // Update is called once per frame (not used)
    void Update() {
    }
}