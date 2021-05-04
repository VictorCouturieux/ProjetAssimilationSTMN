using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCManager : Photon.MonoBehaviour {
    public PhotonView photonView;
    
    private GameObject shipObj;
    
    private float[] serialInfo = null;

    // Start is called before the first frame update
    void Start() {
        shipObj = GameObject.Find("Ship");

        PhotonNetwork.sendRate = 20;
        PhotonNetwork.sendRateOnSerialize = 10;
    }

    // Update is called once per frame
    void Update() {
        if (photonView.isMine) {
            
        }
    }

    private void FixedUpdate() {
        if (!photonView.isMine) {
            
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            
        }
        else {
            
        }
    }

}