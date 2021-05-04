using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerMovement : Photon.MonoBehaviour {
//    public PhotonView photonView;
//    public float moveSpeed = 1;
//    public float timeDelay = 3;
//
//    private bool isOnShip = false;
//    
//    private Rigidbody2D rbody;
//    private Animator anim;
////    private int numPlayer;
//
//    private Rigidbody2D rShip;
//    private Vector2 lastShipPosition;
//    
//    private float[] serialInfo = null;
//    private Vector2 vectDir;
//    private Vector2 selPos;
//
//    private static List<int> listIdOtherPlayer = new List<int>();
//
//    private int initSpownPlayer = 0;
//    
//    private double timer;
//
//
//    // Use this for initialization
//    void Start() {
//        
//        anim = GetComponent<Animator>();
//        
//        rShip = GameObject.Find("Ship(Clone)").GetComponent<Rigidbody2D>();
//        lastShipPosition = rShip.position;
//
//        timer = timeDelay;
//
////        positionInShip = rbody.position - rShip.position;
//    }
//
//    // Update is called once per frame
//    void Update() {
//        if (photonView.isMine) {
//            
//            rbody = GetComponent<Rigidbody2D>();
//            rShip = GameObject.Find("Ship(Clone)").GetComponent<Rigidbody2D>();
//            
//            Vector2 diffLastNewPos = rShip.position - lastShipPosition;
//            transform.Translate(diffLastNewPos);
//            
//            Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
//        
//            if (moveVector != Vector2.zero) {
//                anim.SetBool("isWalking", true);
//                anim.SetFloat("input_x", moveVector.x);
//                anim.SetFloat("input_y", moveVector.y);
//            }
//            else {
//                anim.SetBool("isWalking", false);
//            }
//        
//            Vector2 position = rbody.position;    
//            Vector2 positionToWard = position
//                                     + moveVector * moveSpeed * Time.deltaTime ;
//
//            rbody.MovePosition(Vector2.Lerp(positionToWard, rbody.position, 0));
//            
//            lastShipPosition = GameObject.Find("Ship(Clone)").GetComponent<Rigidbody2D>().position;
//
////            if (GameObject.Find("NetworkManager").GetComponent<SFB_NetworkManager>() != null) {
////                SFB_NetworkManager networkManager =
////                    GameObject.Find("NetworkManager").GetComponent<SFB_NetworkManager>();
////                if (!isOnShip) {
////                    if (PhotonNetwork.offlineMode) {
////                        rbody.MovePosition(GameObject.Find("spown" + networkManager.MyNbPlayer).transform.position);
////                    }
////                    else {
//////                    GetComponent<PhotonView>().RPC("reInitOnLinePlayerPosition", PhotonTargets.All);
////                        rbody.MovePosition(GameObject.Find("spown" + networkManager.MyNbPlayer).transform.position);
////                    }
////                }
////            }
//        }
//        
//    }
//    
//    private void FixedUpdate() {
//        if (!photonView.isMine) {
//            
//            rbody = GetComponent<Rigidbody2D>();
//            
//            rShip = GameObject.Find("Ship(Clone)").GetComponent<Rigidbody2D>();
//            
//            //deplacement du vaiseau
//            Vector2 diffLastNewPos = rShip.position - lastShipPosition;
//            rbody.transform.Translate(diffLastNewPos);
//            
//            //annimation du personnage
//            if (vectDir != Vector2.zero) {
//                anim.SetBool("isWalking", true);
//                anim.SetFloat("input_x", vectDir.x);
//                anim.SetFloat("input_y", vectDir.y);
//            }
//            else {
//                anim.SetBool("isWalking", false);
//            }
//            
//            if (initSpownPlayer<10) {
//                rbody.MovePosition(selPos + rShip.position);
//                initSpownPlayer++;
//            }
//            else {
//                rbody.MovePosition(Vector2.MoveTowards(rbody.position, selPos + rShip.position, Time.fixedDeltaTime));
//            }
//            
//            lastShipPosition = GameObject.Find("Ship(Clone)").GetComponent<Rigidbody2D>().position;
//
//            if (!isOnShip) {
//                rbody.MovePosition(selPos + rShip.position);
//            }
//        }
//    }
//
//    private void OnTriggerExit2D(Collider2D other) {
//        if (other.Equals(GameObject.Find("zoneWhereMove").GetComponent<Collider2D>())) {
//            isOnShip = false;
//        }
//    }
//
//    private void OnTriggerEnter2D(Collider2D other) {
//        if (other.Equals(GameObject.Find("zoneWhereMove").GetComponent<Collider2D>())) {
//            isOnShip = true;
//        }
//    }
//
////    [PunRPC]
////    private void reInitOnLinePlayerPosition() {
////        rbody.MovePosition(GameObject.Find("spown" + numPlayer).transform.position);
////        Debug.Log("TOTOTOTOTOTOTOTOTOTOTOTOTOTOT");
////    }
//
//    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
//        
//        if (stream.isWriting) {
//            rbody = GetComponent<Rigidbody2D>();
//            rShip = GameObject.Find("Ship(Clone)").GetComponent<Rigidbody2D>();
//            Vector2 position = rbody.position;
//            Vector2 positionInShip = position - rShip.position;
//            
//            float[] tabByte = {
//                positionInShip.x, 
//                positionInShip.y, 
//                Input.GetAxisRaw("Horizontal"), 
//                Input.GetAxisRaw("Vertical")
//            };
//            
//            stream.SendNext(tabByte);
//        }
//        else {
//            serialInfo = (float[]) stream.ReceiveNext();
//            
//            vectDir = new Vector2(serialInfo[2], serialInfo[3]);
//            
//            float lag = Mathf.Abs((float) (PhotonNetwork.time - info.timestamp));
//            selPos = new Vector2(serialInfo[0], serialInfo[1]);
//            selPos += vectDir * lag;
//        }
//    }
//
//    public Rigidbody2D GetRBody() {
//        return rbody;
//    }

//    public int NumPlayer {
//        get { return numPlayer; }
//        set { numPlayer = value; }
//    }
}