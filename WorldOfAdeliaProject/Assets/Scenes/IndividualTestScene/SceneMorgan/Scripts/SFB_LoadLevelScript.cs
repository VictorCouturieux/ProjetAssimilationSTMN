using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class LoadLevelScript : MonoBehaviour {
    public GameObject _loadingLobby;
    public GameObject _loadingProgressBar;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    private int nbPlayerMinOnButtonToLoad = 2;
    private bool weCanLoadScene = false;

    private int _nbrePersosSurDalle = 0;

    void Awake() {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
        _nbrePersosSurDalle = 0;
    }

    // Start is called before the first frame update
    void Start() {
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetType() == typeof(CapsuleCollider)) {
            if (other.name.Contains("Player")) {
                Debug.Log(_nbrePersosSurDalle);
                _nbrePersosSurDalle++;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetType() == typeof(CapsuleCollider)) {
            if (other.name.Contains("Player")) {
                _nbrePersosSurDalle--;
            }
        }
    }

    void Update() {
        if (_nbrePersosSurDalle >= nbPlayerMinOnButtonToLoad) {
            if (_nbrePersosSurDalle >= PhotonNetwork.playerList.Length) {
                // lancement de la barre de chargement
                _loadingLobby.SetActive(true);
                if (currentAmount < 100) {
                    currentAmount += speed * Time.deltaTime;
                }
                _loadingProgressBar.GetComponent<Image>().fillAmount = currentAmount / 100;

                // Condition de fin de la barre de chargement
                if (currentAmount >= 100) {
                    if (PhotonNetwork.isMasterClient) {
                        if (PhotonNetwork.offlineMode) {
                            AllLoadChoiceMenuScene();
                        }
                        else {
                            GetComponent<PhotonView>().RPC("AllLoadChoiceMenuScene", PhotonTargets.All);
                        }
                    }
                }
            }
        }
        else {
            //reinitialisation du timer de la barre de chargement
            _loadingLobby.SetActive(false);
            currentAmount = 0;
        }
    }

    [PunRPC]
    public void AllLoadChoiceMenuScene() {
        currentAmount = 0;
        GameManager.instance.NetworkManager.moveSceneChoiceLevel();
    }

    public int _NbrePersosSurDalle {
        get { return _nbrePersosSurDalle; }
        set { _nbrePersosSurDalle = value; }
    }

//    IEnumerator loadScene() {
//        yield return new WaitForSeconds(0.5f);
//        _nbrePersosSurDalle = 0;
//        Debug.Log(_nbrePersosSurDalle);
//    }
}