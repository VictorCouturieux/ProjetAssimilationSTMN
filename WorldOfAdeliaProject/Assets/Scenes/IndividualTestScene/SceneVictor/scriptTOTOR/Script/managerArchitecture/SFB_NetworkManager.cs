using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// The main class NetworkManager
/// instantiate once and automatically in the GameManager 
/// </summary>
/// <remarks>
/// can get all instant of all specific manager
/// and can be call in all unity scene because GameManager is a singleton instance
/// </remarks>
public class SFB_NetworkManager : MonoBehaviour {
    /// <value>
    /// this class can be create or join a room in a network
    /// call by a button on the scene
    /// get the value of name of room 
    /// </value>
    private SFB_PhotonButtons _photonButtons;

    /// <value>this is the actual specific ship in the actual scene (can be null if there is no ship)</value>>
    private GameObject _shipInstance;

    public GameObject ShipInstance {
        get { return _shipInstance; }
        set { _shipInstance = value; }
    }

    ///<summary>
    /// Awake is always called before any Start functions
    /// </summary>
    private void Awake() {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    // Start is called before the first frame update (not used)
    void Start() {
    }

    /// <summary>
    /// can be create a new room in a network
    /// </summary>
    public void createNewRoom() {
        PhotonNetwork.CreateRoom(_photonButtons.createRoomInput.text, new RoomOptions() {
            isVisible = true,
            IsOpen = true,
            MaxPlayers = 4
        }, TypedLobby.Default);
        Debug.Log("Room Created");
    }

    /// <summary>
    /// can be create or join a new room in a network
    /// </summary>
    public void joinOrCreateRoom() {
        Debug.Log("JOIN Room");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_photonButtons.joinRoomInput.text, roomOptions, TypedLobby.Default);
    }

    /// <summary>
    /// can be call in all scene by all script to move the player in the "SFB_LobbyShipScene" scene.
    /// </summary>
    public void moveSceneLobby() {
        if (PhotonNetwork.isMasterClient)
            PhotonNetwork.room.IsOpen = true;
        PhotonNetwork.LoadLevel(GameManager.nameSceneLobbyShipToLoad);
    }

    /// <summary>
    /// can be call in all scene by all script to move the player in the "SFB_ChoiceLevelScene" scene.
    /// </summary>
    public void moveSceneChoiceLevel() {
        if (PhotonNetwork.isMasterClient)
            PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.LoadLevel(GameManager.nameSceneChoiceLevelToLoad);
    }

    /// <summary>
    /// can be call in all scene by all script to move the player in the "SFB_GameLevel0Scene"  scene.
    /// </summary>
    public void moveSceneLevel0() {
        if (PhotonNetwork.isMasterClient)
            PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.LoadLevel(GameManager.nameScenelevel0ToLoad);
    }

    /// <summary>
    /// can be call in all scene by all script to move the player in the "SFB_GameLevel1Scene" scene.
    /// </summary>
    public void moveSceneLevel1() {
        if (PhotonNetwork.isMasterClient)
            PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.LoadLevel(GameManager.nameScenelevel1ToLoad);
    }

    /// <summary>
    /// can be call in all scene by all script to move the player in the "SFB_GameLevel2Scene" scene.
    /// </summary>
    public void moveSceneLevel2() {
        if (PhotonNetwork.isMasterClient)
            PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.LoadLevel(GameManager.nameScenelevel2ToLoad);
    }

    /// <summary>
    /// call by a listener button to Join room
    /// </summary>
    private void OnJoinedRoom() {
        moveSceneLobby();
        Debug.Log("we are connected to the room LOBBY!");
    }

    /// <summary>
    /// this is to call when the GameManager changes Unity scene.
    /// </summary>
    /// <param name="scene">scene to load</param>
    /// <param name="mode">load Scene mode (not used)</param>
    /// <remarks>Have specify instruction in all different scene</remarks>
    /// <remarks>
    /// duplicate code but it is explicit if we must make a particular change in a particular scene
    /// </remarks>
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
//        Debug.Log("Log network Manager");

        //by default the ship instance is null
        ShipInstance = null;

        if (scene.name == GameManager.nameSceneMainMenuToLoad) {
        }
        else if (scene.name == GameManager.nameSceneConnectServerToLoad) {
            //Check if there is already an instance of PhotonButton
            if (_photonButtons == null)
                //if not, set it to this.
                _photonButtons = GameObject.Find("PhotonScript").GetComponent<SFB_PhotonButtons>();
        }
        else if (scene.name == GameManager.nameSceneLobbyShipToLoad) {
            //if you are the master player of the room network them you create a LobbyShip
            if (PhotonNetwork.isMasterClient) {
                // reset all object in the network scene
                PhotonNetwork.DestroyAll();
                //Master player instantiate specifique ship in lobby
                ShipInstance = PhotonNetwork.InstantiateSceneObject("LobbyShip",
                    GameObject.Find("SpownShip").transform.position,
                    GameObject.Find("SpownShip").transform.rotation,
                    0,
                    null
                ) as GameObject;
            }
        }
        else if (scene.name == GameManager.nameSceneChoiceLevelToLoad) {
        }
        else if (scene.name == GameManager.nameScenelevel0ToLoad) {
            //if you are the master player of the room network them you create a Ship
            if (PhotonNetwork.isMasterClient) {
                // reset all object in the network scene
                PhotonNetwork.DestroyAll();
                //Master player instantiate ship in level 0
                ShipInstance = PhotonNetwork.InstantiateSceneObject("Ship",
                    GameObject.Find("SpownShip").transform.position,
                    GameObject.Find("SpownShip").transform.rotation,
                    0,
                    null
                ) as GameObject;
            }
        }
        else if (scene.name == GameManager.nameScenelevel1ToLoad) {
            //if you are the master player of the room network them you create a Ship
            if (PhotonNetwork.isMasterClient) {
                // reset all object in the network scene
                PhotonNetwork.DestroyAll();
                //Master player instantiate ship in level 0
                ShipInstance = PhotonNetwork.InstantiateSceneObject("Ship",
                    GameObject.Find("SpownShip").transform.position,
                    GameObject.Find("SpownShip").transform.rotation,
                    0,
                    null
                ) as GameObject;
            }
        }
        else if (scene.name == GameManager.nameScenelevel2ToLoad) {
            //if you are the master player of the room network them you create a Ship
            if (PhotonNetwork.isMasterClient) {
                // reset all object in the network scene
                PhotonNetwork.DestroyAll();
                //Master player instantiate ship in level 0
                ShipInstance = PhotonNetwork.InstantiateSceneObject("Ship",
                    GameObject.Find("SpownShip").transform.position,
                    GameObject.Find("SpownShip").transform.rotation,
                    0,
                    null
                ) as GameObject;
            }
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    /// <remarks>Have specify instruction in all different scene</remarks>
    /// <remarks>
    /// duplicate code but it is explicit if we must make a particular change in a particular scene
    /// </remarks>
    void Update() {
        if (SceneManager.GetActiveScene().name == GameManager.nameSceneMainMenuToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneConnectServerToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneLobbyShipToLoad) {
            //All player refresh the ship for all player
            if (ShipInstance == null) {
                if (GameObject.Find("LobbyShip(Clone)")) {
                    ShipInstance = GameObject.Find("LobbyShip(Clone)");
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneChoiceLevelToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel0ToLoad) {
            //All player refresh the ship for all player
            if (ShipInstance == null) {
                if (GameObject.Find("Ship(Clone)")) {
                    ShipInstance = GameObject.Find("Ship(Clone)");
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel1ToLoad) {
            //All player refresh the ship for all player
            if (ShipInstance == null) {
                if (GameObject.Find("Ship(Clone)")) {
                    ShipInstance = GameObject.Find("Ship(Clone)");
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel2ToLoad) {
            //All player refresh the ship for all player
            if (ShipInstance == null) {
                if (GameObject.Find("Ship(Clone)")) {
                    ShipInstance = GameObject.Find("Ship(Clone)");
                }
            }
        }
    }
}