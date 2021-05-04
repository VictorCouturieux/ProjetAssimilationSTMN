using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// used to move ship on the network
/// </summary>
/// <remarks>
/// can be optimised but requires more time reflection
/// </remarks>
public class SFB_ShipStatement : MonoBehaviour {
    /// <value>
    /// Photon View instance
    /// use to set information of player movement
    /// </value>
    public PhotonView photonView;

    /// <value>left lateral ship movement script Button</value>
    public SFB_ShipMove leftMove;

    /// <value>right lateral ship movement script Button</value>
    public SFB_ShipMove righMove;

    /// <value>to fast top speed ship movement script Button</value>
    public SFB_ShipSpeed moreSpeedMove;

    /// <value>to slow top speed ship movement script Button</value>
    public SFB_ShipSpeed slowMove;

    /// <value>ship movement animation</value>
    public Animator animShip;

    /// <value>lateral speed ship movement</value>
    public static float lateralSpeedShipMove = 0.2f;

    /// <value>
    /// float list of information to concatenate all informations about player Instance share in the network
    /// </value>
    private float[] serialInfo = null;

    /// <value>lateral ship movement statement</value>
    private GameObject driverStat;

    public GameObject DriverStat {
        get { return driverStat; }
        set { driverStat = value; }
    }

    /// <value>physique ship body instance</value>
    private Rigidbody rShip;

    /// <value>counter number of ship spawn in early connection of the room</value>
    private int initSpawnShip = 0;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        rShip = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixedUpdate() has the frequency of the physics system; it is called every fixed frame-rate frame.
    /// </summary>
    /// <remarks>
    /// the ship instruction :
    /// my local ship instance 
    /// and network information of ship instance send by other player
    /// </remarks>
    void FixedUpdate() {
        //get first lateral driver information
        if (leftMove.IsTrygger && driverStat == null) {
            driverStat = leftMove.Driver.gameObject;
        }
        else if (righMove.IsTrygger && driverStat == null) {
            driverStat = righMove.Driver.gameObject;
        }
        else {
            driverStat = null;
        }

        //ship position initialisation by the master player
        if (!PhotonNetwork.isMasterClient) {
            if (rShip != null && serialInfo != null) {
                if (initSpawnShip < 10) {
                    rShip.MovePosition(new Vector3(serialInfo[0], rShip.position.y, rShip.position.z));
                    initSpawnShip++;
                }

                //////////////////////////////////////////////////
                // IDEA OF OF NETWORK CODE TESTING  : not work  //
                //////////////////////////////////////////////////

//                else {
//                    rShip.transform.position = Vector3.MoveTowards(
//                        rShip.position,
//                        new Vector3(serialInfo[0], rShip.position.y, 0),
//                        Time.fixedDeltaTime * speedShipMove);
//                }
            }
        }

        // local lateral ship movement for all player
        // but synchronise when driver player leave the button (show SFB_ShipMove.sc -> OnTriggerExit() )
        // it is the must solution we found to synchronize the ship position with all player position 
        // we have no slow slider player character movement on the ship with this method
        // i think that is optimizable but requires more time reflection
        if (leftMove.IsTrygger && !righMove.IsTrygger) {
            if (rShip.position.x > -1.72)
                rShip.MovePosition(rShip.position + Vector3.left * lateralSpeedShipMove * Time.fixedDeltaTime);
        }
        else if (!leftMove.IsTrygger && righMove.IsTrygger) {
            if (rShip.position.x < 1.68)
                rShip.MovePosition(rShip.position + Vector3.right * lateralSpeedShipMove * Time.fixedDeltaTime);
        }
        else if (leftMove.IsTrygger && righMove.IsTrygger || !leftMove.IsTrygger && !righMove.IsTrygger) {
//                rShip.MovePosition(rShip.position + Vector2.zero * speedShipMove * Time.deltaTime);
        }
//        Debug.Log(rShip.position);


        // top speed mode to change speed ship animation
        int speed_mod = 0;

        // top speed ship movement for all player
        if (SceneManager.GetActiveScene().name != GameManager.nameSceneLobbyShipToLoad) {
            if (moreSpeedMove != null && slowMove != null) {
                if (!moreSpeedMove.IsTrygger && slowMove.IsTrygger) {
                    // change lateral speed movement
                    lateralSpeedShipMove = 0.275f;

                    // change top speed mode
                    speed_mod = 1;

                    // RPC method create by BILLAUD PIERRE called to change the speed scrolling to slow 
                    // team communication problem : the method name does not correspond
                    Level.instance.setSpeedBackgroundToNormal();
                }
                else if (moreSpeedMove.IsTrygger && !slowMove.IsTrygger) {
                    // change lateral speed movement
                    lateralSpeedShipMove = 0.15f;

                    // change top speed mode
                    speed_mod = 3;

                    // RPC method create by BILLAUD PIERRE called to change the speed scrolling to fast
                    // team communication problem : the method name does not correspond
                    Level.instance.setSpeedBackgroundToVeryFast();
                }
                else if (moreSpeedMove.IsTrygger && slowMove.IsTrygger ||
                         !moreSpeedMove.IsTrygger && !slowMove.IsTrygger) {
                    // change lateral speed movement
                    lateralSpeedShipMove = 0.2f;

                    // change top speed mode
                    speed_mod = 2;

                    // RPC method create by BILLAUD PIERRE called to change the speed scrolling to a normal speed
                    // team communication problem : the method name does not correspond
                    Level.instance.setSpeedBackgroundToFast();
                }
            }
        }

        // update speed ship animation
        animShip.SetInteger("speed", speed_mod);

        //////////////////////////////////////////////////
        // IDEA OF OF NETWORK CODE TESTING  : not work  //
        //////////////////////////////////////////////////

//        if (driverStat != GameObject.Find("PlayerManager").GetComponent<PlayerManager>().MainPlayer) {
//            if (leftMove.IsTryger && !righMove.IsTryger) {
//                Debug.Log("left");
//                rShip.MovePosition(rShip.position + Vector3.left * speedShipMove * Time.fixedDeltaTime);
//            }
//            else if (!leftMove.IsTryger && righMove.IsTryger) {
//                Debug.Log("right");
//                rShip.MovePosition(rShip.position + Vector3.right * speedShipMove * Time.fixedDeltaTime);
//            }
//            else if (leftMove.IsTryger && righMove.IsTryger || !leftMove.IsTryger && !righMove.IsTryger) {
////                rShip.MovePosition(rShip.position + Vector2.zero * speedShipMove * Time.deltaTime);
//            }
//        }

        //////////////////////////////////////////////////
        // IDEA OF OF NETWORK CODE TESTING  : not work  //
        //////////////////////////////////////////////////
        
//        if (driverStat == GameObject.Find("PlayerManager").GetComponent<PlayerManager>().MainPlayer) {
//            
////            if (leftMove.IsTryger && !righMove.IsTryger) {
////                Debug.Log("left");
////                rShip.MovePosition(rShip.position + Vector3.left * speedShipMove * Time.fixedDeltaTime);
////            }
////            else if (!leftMove.IsTryger && righMove.IsTryger) {
////                Debug.Log("right");
////                rShip.MovePosition(rShip.position + Vector3.right * speedShipMove * Time.fixedDeltaTime);
////            }
////            else if (leftMove.IsTryger && righMove.IsTryger || !leftMove.IsTryger && !righMove.IsTryger) {
//////                rShip.MovePosition(rShip.position +s Vector2.zero * speedShipMove * Time.deltaTime);
////            }
//            if (leftMove.IsTryger && !righMove.IsTryger) {
//                Debug.Log("left");
//                rShip.MovePosition(rShip.position + Vector3.left * speedShipMove * Time.fixedDeltaTime);
//            }
//            else if (!leftMove.IsTryger && righMove.IsTryger) {
//                Debug.Log("right");
//                rShip.MovePosition(rShip.position + Vector3.right * speedShipMove * Time.fixedDeltaTime);
//            }
//            else if (leftMove.IsTryger && righMove.IsTryger || !leftMove.IsTryger && !righMove.IsTryger) {
////                rShip.MovePosition(rShip.position + Vector2.zero * speedShipMove * Time.deltaTime);
//            }
//            SyncroPosition(rShip.position);
//        }
//        else {
//            
//        }

        //////////////////////////////////////////////////
        // IDEA OF OF NETWORK CODE TESTING  : not work  //
        //////////////////////////////////////////////////
        
//        if (driverStat == GameObject.Find("PlayerManager").GetComponent<PlayerManager>().MainPlayer) {
//            if (primarVect != Vector3.zero) {
//                rShip.transform.position = Vector3.MoveTowards(
//                    rShip.position,
//                    new Vector3(primarVect.x, rShip.position.y, 0),
//                    Time.deltaTime * speedShipMove);
//                if (primarVect.x.Equals(rShip.position.x)) {
//                    primarVect = Vector3.zero;
//                    Debug.Log("SyncroShipPosition : " + rShip.position.x + ", " + rShip.position.y);
//                }
//            }
//        }
    }

    /// <summary>
    /// call RPC method when driver player leave lateral movement button
    /// </summary>
    /// <param name="vect">new ship position synchronized</param>
    public void SyncroPosition(Vector3 vect) {
        if (PhotonNetwork.offlineMode) {
            SyncroPositionRPC(rShip.position, new PhotonMessageInfo());
        }
        else {
            GetComponent<PhotonView>().RPC("SyncroPositionRPC", PhotonTargets.Others, rShip.position);
        }
    }

    /// <summary>
    /// is RPC method
    /// synchronize ship position with all other player when driver player leave lateral movement button
    /// </summary>
    /// <param name="vect">new ship position synchronized</param>
    /// <param name="info">network information. for example the lag with timestamp value</param>
    [PunRPC]
    public void SyncroPositionRPC(Vector3 vect, PhotonMessageInfo info) {
        //////////////////////////////////////////////////
        // IDEA OF OF NETWORK CODE TESTING  : not work  //
        //////////////////////////////////////////////////

//        Debug.Log("SyncroPosition : " + vect.x + ", " + vect.y);
//        rShip.MovePosition(Vector3.MoveTowards(
//            rShip.position,
//            new Vector3(vect.x, rShip.position.y, 0),
//            Time.fixedDeltaTime * speedShipMove));
//        rShip.AddForce(new Vector2(vect.x, rShip.position.y) - rShip.position);
//        rShip.MovePosition(new Vector2(vect.x, vect.y));
//        primarVect = new Vector3(vect.x, rShip.position.y, 0);

        //must method to synchronize
        rShip.transform.position = new Vector3(vect.x, rShip.position.y, rShip.position.z);

//        Debug.Log("SyncroShipPosition : " + rShip.position.x + ", " + rShip.position.y);
    }

    /// <summary>
    /// synchronization method used by PhotonView Object to send and receive network player information on the ship
    /// call foreach update frame to send new information
    /// </summary>
    /// <param name="stream">Serialise network information</param>
    /// <param name="info">network information. for example the lag with timestamp value</param>
    /// <remarks>
    /// NOT USED
    /// </remarks>
    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            if (PhotonNetwork.isMasterClient) {
                //send just the X ship position
                float[] tabByte = {
                    rShip.position.x
                };
                stream.SendNext(tabByte);
            }
        }
        else {
            if (!PhotonNetwork.isMasterClient) {
                serialInfo = (float[]) stream.ReceiveNext();
            }
        }
    }
}