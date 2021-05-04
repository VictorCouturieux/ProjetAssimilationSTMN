using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour {
    public string versionName = "0.1";

    public GameObject sectionView1, sectionView2, sectionView3;

//    public void connectToPhoton()
//    {
//        PhotonNetwork.ConnectUsingSettings(versionName);
//        
//        Debug.Log("connect to photon");
//    }

    private void Awake() {
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("connect to photon");
    }

    private void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connected to master");
    }

    private void OnJoinedLobby() {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        Debug.Log("On Joined Lobby");
    }

    private void OnDisconnectedFromPhoton() {
        if (sectionView1.GetActive())
            sectionView1.SetActive(false);
        if (sectionView2.GetActive())
            sectionView2.SetActive(false);

        sectionView3.SetActive(true);

        Debug.Log("Dis from photon services");
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }
}