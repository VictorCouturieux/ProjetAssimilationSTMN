using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Photon.MonoBehaviour {
    public bool devTesting = false;

    public PhotonView photonView;

//    public GameObject playerCam;

    public float moveSpeed = 100f;

    private Vector3 selPos;

//    private GameObject sceneCam;

    // Start is called before the first frame update
    void Start() {
    }

//    private void Awake()
//    {
//        if (!devTesting && photonView.isMine)
//        {
//            sceneCam = GameObject.Find("Main Camera");
////            Debug.Log(sceneCam);
//            sceneCam.SetActive(false);
//            playerCam.SetActive(true);
//        }
//        
//    }

    // Update is called once per frame
    void Update() {
        if (!devTesting) {
            if (photonView.isMine)
                checkedInput();
            else
                smoothNetMovement();
        }
        else {
            checkedInput();
        }
    }

    private void checkedInput() {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void smoothNetMovement() {
        transform.position = Vector3.Lerp(transform.position, selPos, Time.deltaTime * 8);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(transform.position);
        }
        else {
            selPos = (Vector3) stream.ReceiveNext();
        }
    }
}