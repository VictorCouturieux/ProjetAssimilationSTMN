using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by COUTURIEUX VICTOR in collaboration with BUCHER MORGAN
/// used to show everyone who is the master player in real time
/// </summary>
public class SFB_ShowMasterName : MonoBehaviour {
    /// <value>
    /// Text instance to shown the master name
    /// </value>
    [SerializeField] private Text _masterNameText;

    public Text MasterNameText {
        get { return _masterNameText; }
        set { _masterNameText = value; }
    }

    // Start is called before the first frame update (not used)
    void Start() {
    }

    // Update is called once per frame (not used)
    void Update() {
    }

    /// <summary>
    /// call by master player to show his name
    /// </summary>
    /// <param name="name">new master name</param>
    public void Show(String name) {
        if (PhotonNetwork.isMasterClient) {
            if (PhotonNetwork.offlineMode) {
                ShowMasterName(name);
            }
            else {
                GetComponent<PhotonView>().RPC("ShowMasterName", PhotonTargets.All, name);
            }
        }
    }

    /// <summary>
    /// is RPC method 
    /// call to set Master player name on the Text instance 
    /// </summary>
    /// <param name="name">new master name</param>
    [PunRPC]
    public void ShowMasterName(String name) {
        MasterNameText.text = name;
    }
}