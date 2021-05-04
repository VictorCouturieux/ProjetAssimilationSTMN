using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// The main class PlayerManager
/// instantiate once and automatically in the GameManager 
/// </summary>
/// <remarks>
/// can get all instant of all specific manager
/// and can be call in all unity scene because GameManager is a singleton instance
/// </remarks>
/// <remarks>
/// just manage player character of player in the network to differentiate my player from all the other
/// </remarks>
public class SFB_PlayerManager : MonoBehaviour {
    /// <value>
    /// player character prefab (GameObject)
    /// </value>
    public GameObject prefabPlayer;

    ///<value>this value can be used to know if the player are enter in the game in network ( room of photon network)</value> 
    private bool _enterInGame = false;

    public bool EnterInGame {
        get { return _enterInGame; }
        set { _enterInGame = value; }
    }

    /// <value>
    /// my player character prefab instance
    /// </value>
    private GameObject _myPlayerInstance;

    public GameObject MyPlayerInstance {
        get { return _myPlayerInstance; }
        set { _myPlayerInstance = value; }
    }

    /// <value>
    /// my player number in the current room
    /// </value>
    private int myNbPlayer;

    public int MyNbPlayer {
        get { return myNbPlayer; }
        set { myNbPlayer = value; }
    }

    /// <value>
    /// my player name(pseudonym) choice by me
    /// </value>    
    private String _pseudoPlayerName;

    public String PseudoPlayerName {
        get { return _pseudoPlayerName; }
        set { _pseudoPlayerName = value; }
    }

    /// <value>
    /// my player color number random choice but can be change by player on the Lobby Ship
    /// </value>    
    private int _numbercolor;

    public int Numbercolor {
        get { return _numbercolor; }
        set { _numbercolor = value; }
    }

    ///<summary>
    /// Awake is always called before any Start functions
    /// </summary>
    void Awake() {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
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
//        Debug.Log("Log player Manager");

        //by default the player instance is null
        MyPlayerInstance = null;

        if (scene.name == GameManager.nameSceneMainMenuToLoad) {
            // no enter in game
            EnterInGame = false;
        }
        else if (scene.name == GameManager.nameSceneConnectServerToLoad) {
            // no enter in game
            EnterInGame = false;
        }
        else if (scene.name == GameManager.nameSceneLobbyShipToLoad) {
        }
        else if (scene.name == GameManager.nameSceneChoiceLevelToLoad) {
        }
        else if (scene.name == GameManager.nameScenelevel0ToLoad) {
        }
        else if (scene.name == GameManager.nameScenelevel1ToLoad) {
        }
        else if (scene.name == GameManager.nameScenelevel2ToLoad) {
        }
    }

    // Start is called before the first frame update
    void Start() {
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
            if (MyPlayerInstance == null) {
                if (GameManager.instance.NetworkManager.ShipInstance != null) {
                    if (!EnterInGame) {
                        // this is for the first spawn player prefab instantiation to give a number at the player
                        spawnPlayerFirst();
                        // enter the game contition
                        EnterInGame = true;
                    }
                    else {
                        // this is for the other spawn player prefab instantiation when you have number at the player in this room
                        spawnPlayerAfterFirst();
                    }
                }
            }
            else {
                //update number player if a player disconnect (leaveGame)
                if (myNbPlayer > PhotonNetwork.otherPlayers.Length) {
                    myNbPlayer--;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneChoiceLevelToLoad) {
            if (PhotonNetwork.isMasterClient) {
                // if you are a master player then in this scene you change in real time for all player
                SFB_ShowMasterName MasterName = GameObject.Find("MasterName").GetComponent<SFB_ShowMasterName>();
                //'Show' method is an RPC network function
                MasterName.Show(PseudoPlayerName);
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel0ToLoad) {
            // this is for the other spawn player prefab instantiation when you have number at the player in this room
            if (MyPlayerInstance == null) {
                if (GameManager.instance.NetworkManager.ShipInstance != null) {
                    spawnPlayerAfterFirst();
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel1ToLoad) {
            // this is for the other spawn player prefab instantiation when you have number at the player in this room
            if (MyPlayerInstance == null) {
                if (GameManager.instance.NetworkManager.ShipInstance != null) {
                    spawnPlayerAfterFirst();
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel2ToLoad) {
            // this is for the other spawn player prefab instantiation when you have number at the player in this room
            if (MyPlayerInstance == null) {
                if (GameManager.instance.NetworkManager.ShipInstance != null) {
                    spawnPlayerAfterFirst();
                }
            }
        }
    }

    /// <summary>
    /// this is for the other spawn player prefab instantiation when you have number at the player in this room
    /// </summary>
    private void spawnPlayerAfterFirst() {
        MyPlayerInstance = PhotonNetwork.Instantiate(prefabPlayer.name,
            GameObject.Find("spown" + myNbPlayer).transform.position,
            prefabPlayer.transform.rotation,
            0);
    }

    /// <summary>
    /// this is for the first spawn player prefab instantiation to give a number at the player
    /// </summary>
    private void spawnPlayerFirst() {
        if (PhotonNetwork.otherPlayers.Length == 1) {
            MyPlayerInstance = PhotonNetwork.Instantiate(prefabPlayer.name,
                GameObject.Find("spown1").transform.position,
                prefabPlayer.transform.rotation,
                0);
            myNbPlayer = 1;
        }
        else if (PhotonNetwork.otherPlayers.Length == 2) {
            MyPlayerInstance = PhotonNetwork.Instantiate(prefabPlayer.name,
                GameObject.Find("spown2").transform.position,
                prefabPlayer.transform.rotation,
                0);
            myNbPlayer = 2;
        }
        else if (PhotonNetwork.otherPlayers.Length == 3) {
            MyPlayerInstance = PhotonNetwork.Instantiate(prefabPlayer.name,
                GameObject.Find("spown3").transform.position,
                prefabPlayer.transform.rotation,
                0);
            myNbPlayer = 3;
        }
        else {
            MyPlayerInstance = PhotonNetwork.Instantiate(prefabPlayer.name,
                GameObject.Find("spown0").transform.position,
                prefabPlayer.transform.rotation,
                0);
            myNbPlayer = 0;
        }

        //set a random color in the first spanw
        Numbercolor = Random.Range(0, 9);
    }
}