using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// The main class GameManager
/// instantiate automatically a game manager if it not exist
/// </summary>
/// <remarks>
/// can get all instant of all specific manager
/// and can be call in all unity scene because GameManager is a singleton instance
/// </remarks>
public class GameManager : MonoBehaviour {
    /// <value>Instance of GameManager</value>
    public static GameManager
        instance = null; //Static instance of GameManager which allows it to be accessed by any other script

    ///<value>SoundManager singleton manager</value> 
    [SerializeField] private SFB_SoundManager _soundManager; //SoundManager prefab to instantiate.

    public SFB_SoundManager SoundManager {
        get { return _soundManager; }
        set { _soundManager = value; }
    }

    ///<value>NetworkManager singleton manager</value> 
    [SerializeField] private SFB_NetworkManager _networkManager; //NetworkManager prefab to instantiate.

    public SFB_NetworkManager NetworkManager {
        get { return _networkManager; }
        set { _networkManager = value; }
    }

    ///<value>NetworkManager singleton manager</value> 
    [SerializeField] private SFB_PlayerManager _playerManager; //PlayerManager prefab to instantiate.

    public SFB_PlayerManager PlayerManager {
        get { return _playerManager; }
        set { _playerManager = value; }
    }

    ///<value>this value can be used to know if we are in the game in network</value> 
    private bool _isInGame;

    public bool IsInGame {
        get { return _isInGame; }
        set { _isInGame = value; }
    }

    /// <value>
    /// init in static all name scene.
    /// can be use in all unity scene to grab name of every scene.
    /// </value>
    public static string nameSceneMainMenuToLoad = "SFB_MainMenuScene";

    public static string nameSceneConnectServerToLoad = "SFB_ConnectServerScene";
    public static string nameSceneLobbyShipToLoad = "SFB_LobbyShipScene";
    public static string nameSceneChoiceLevelToLoad = "SFB_ChoiceLevelScene";
    public static string nameScenelevel0ToLoad = "SFB_GameLevel0Scene";
    public static string nameScenelevel1ToLoad = "SFB_GameLevel1Scene";
    public static string nameScenelevel2ToLoad = "SFB_GameLevel2Scene";


    ///<summary>
    /// Awake is always called before any Start functions
    /// </summary>
    void Awake() {
//        Debug.Log("init GameManager");
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //this is to call "OnSceneFinishedLoading" method when the GameManager changes Unity scene.
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
        // by default you are not in game
        IsInGame = false;

        if (scene.name == GameManager.nameSceneMainMenuToLoad) {
        }
        else if (scene.name == GameManager.nameSceneConnectServerToLoad) {
        }
        else if (scene.name == GameManager.nameSceneLobbyShipToLoad) {
        }
        else if (scene.name == GameManager.nameSceneChoiceLevelToLoad) {
        }
        else if (scene.name == GameManager.nameScenelevel0ToLoad) {
            //you are in game
            IsInGame = true;
        }
        else if (scene.name == GameManager.nameScenelevel1ToLoad) {
            //you are in game
            IsInGame = true;
        }
        else if (scene.name == GameManager.nameScenelevel2ToLoad) {
            //you are in game
            IsInGame = true;
        }
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }
}