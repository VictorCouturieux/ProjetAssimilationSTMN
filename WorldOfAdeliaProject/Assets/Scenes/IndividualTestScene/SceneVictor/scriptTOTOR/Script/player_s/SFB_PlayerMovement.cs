using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using Random = System.Random;


/// <summary>
/// Created by COUTURIEUX VICTOR
/// used to move player on the network
/// </summary>
/// <remarks>
/// can be optimised but requires more time reflection
/// </remarks>
public class SFB_PlayerMovement : MonoBehaviour {
    /// <value>
    /// Photon View instance
    /// use to set information of player movement
    /// </value>
    public PhotonView photonView;

    /// <value>move speed of the player</value>
    public float moveSpeed = 1;

    /// <value>used to checked is the player is always in the ship </value>
    private bool isOnShip = false;

    /// <value>player texture can be change color</value>
    public Renderer rendTextColor;

    /// <value>library of color material</value>
    public Material[] materials;

    /// <value>name TextMesh player above player instance (pseudonym)</value>
    public TextMesh pseudoTextMesh;

    /// <value>player physique component</value>
    private Rigidbody rbody;

    /// <value>player animation</value>
    public Animator anim;

    /// <value>ship physique component</value>
    private Rigidbody rShip;

    /// <value>last ship position synchronized with all player</value>
    private Vector3 lastShipPosition;

    /// <value>
    /// float list of information to concatenate all informations about player Instance share in the network
    /// </value>
    private float[] serialInfo = null;

    private Vector3 vectDir;
    private Vector3 selPos;
    private int numOneLinePlayer;
    private int colorOneLinePlayer;

    /// <value> information not concatenate in the float list because there may be loss of information</value>
    private String pseudoOnelinePlayer = "";

    /// <value>counter number of spawn in early connection of the room</value>
    private int initSpawnPlayer = 0;

    /// <value>last player rotation synchronized with all player</value>
    private float lastRotation;

    /// <value>move speed of the player with dash instruction</value>
    public float dashSpeed;

    /// <value>timer dash instruction</value>
    private float dashTime;

    public float startDashTime;

    /// <value>dash particle system </value>
    public GameObject particuleDash;

    /// <value>is dash instruction</value>
    private bool dash;

    /// <value> is remake synchronization</value>
    private bool resyncro = false;

    /// <value> synchronization timer </value>
    public float resyncroTimeDelay = 30;

    private float resyncroTimer;

    ///<summary>
    /// Awake is always called before any Start functions
    /// </summary>
    private void Awake() {
        rbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }

    /// <summary>
    /// Start is called before the first frame update
    /// init specific value
    /// </summary>
    void Start() {
        resyncroTimer = resyncroTimeDelay;
        dashTime = startDashTime;
        dash = false;

        lastRotation = 180;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    /// <remarks>
    /// had to condition for the network instruction :
    /// is my player instance
    /// or is other player instance
    /// </remarks>
    void FixedUpdate() {
        if (GameManager.instance.NetworkManager.ShipInstance != null) {
            //checked the instance of the ship to set new information in real time
            rShip = GameManager.instance.NetworkManager.ShipInstance.GetComponent<Rigidbody>();
            transform.parent = rShip.transform;
            lastShipPosition = rShip.position;
        }

        if (rShip != null) {
            if (photonView.isMine) {
                // is my player instance 
                // managed in local scene

                //My color management
                rendTextColor.enabled = true;
                rendTextColor.sharedMaterial =
                    materials[GameManager.instance.PlayerManager.MyNbPlayer];
                getColorOnPlayer(GameManager.instance.PlayerManager.Numbercolor);

                //name player management (pseudonym)
                if (!GameManager.instance.IsInGame) {
                    pseudoTextMesh.text = GameManager.instance.PlayerManager.PseudoPlayerName;
                }
                else {
                    pseudoTextMesh.text = "";
                }

                // get direction vector
                Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

                // player look direction with Xbox controller and computer keyboard
                if (moveVector.x > -0.5 && moveVector.x < 0.5 && moveVector.y <= 1 && moveVector.y > 0)
                    lastRotation = 0;
                else if (moveVector.x > -0.5 && moveVector.x < 0.5 && moveVector.y >= -1 && moveVector.y < 0)
                    lastRotation = 180;
                else if (moveVector.x <= 1 && moveVector.x > 0 && moveVector.y > -0.5 && moveVector.y < 0.5)
                    lastRotation = 90;
                else if (moveVector.x >= -1 && moveVector.x < 0 && moveVector.y > -0.5 && moveVector.y < 0.5)
                    lastRotation = -90;
                else if (moveVector.x <= 1 && moveVector.x > 0.5 && moveVector.y <= 1 && moveVector.y > 0.5)
                    lastRotation = 45;
                else if (moveVector.x <= 1 && moveVector.x > 0.5 && moveVector.y >= -1 && moveVector.y < -0.5)
                    lastRotation = 135;
                else if (moveVector.x >= -1 && moveVector.x < -0.5 && moveVector.y <= 1 && moveVector.y > 0.5)
                    lastRotation = -45;
                else if (moveVector.x >= -1 && moveVector.x < -0.5 && moveVector.y >= -1 && moveVector.y < -0.5)
                    lastRotation = -135;
                transform.eulerAngles = new Vector3(lastRotation, 90, -90);

                //Dash condition 
//            Debug.Log("is Dashing : " + anim.GetBool("is_dashing"));
                if (Input.GetButtonDown("Dash")) {
                    if (dashTime <= 0) {
                        dashTime = startDashTime;
                    }
                    else {
                        dashTime -= Time.fixedDeltaTime;
                        rbody.velocity = Vector3.zero;
                        //RPC network instruction called to synchronize my dash
                        if (moveVector != Vector3.zero) {
                            if (PhotonNetwork.offlineMode)
                                SynchDashRPC(moveVector);
                            else
                                GetComponent<PhotonView>().RPC("SynchDashRPC", PhotonTargets.All, moveVector);
                        }
                    }
                }

                // player animation
                if (moveVector != Vector3.zero) {
                    anim.SetBool("is_walking", true);
                }
                else {
                    anim.SetBool("is_walking", false);
                }

                //player movement in local scene
                Vector3 positionToWard = rbody.position
                                         + moveVector.normalized * moveSpeed * Time.fixedDeltaTime;
                rbody.MovePosition(Vector3.Lerp(positionToWard, rbody.position, 0));

                lastShipPosition = rShip.position;

                //player spawn on ship if he is outside ship in local scene
                if (!isOnShip) {
                    //spawn into player spawn number 
                    rbody.MovePosition(GameObject.Find("spown" + GameManager.instance.PlayerManager.MyNbPlayer)
                        .transform
                        .position);

                    //synchronize all player with RPC methode
                    if (PhotonNetwork.offlineMode) {
                        RespawnOtherPlayer();
                    }
                    else {
                        GetComponent<PhotonView>().RPC("RespawnOtherPlayer", PhotonTargets.Others);
                    }
                }
            }
            else if (!photonView.isMine) {
                // is other player instance
                // managed with network information send by other player

                if (GameManager.instance.NetworkManager.ShipInstance != null) {
                    // checked if the network information send by other player is Null
                    if (serialInfo != null) {
                        //other color managment
                        rendTextColor.enabled = true;
                        rendTextColor.sharedMaterial =
                            materials[numOneLinePlayer];
                        getColorOnPlayer(colorOneLinePlayer);

                        //name player management (pseudonym)
                        if (!GameManager.instance.IsInGame) {
                            if (pseudoOnelinePlayer != "") {
                                pseudoTextMesh.text = pseudoOnelinePlayer;
                            }
                        }
                        else {
                            pseudoTextMesh.text = "";
                        }

                        // player look direction with Xbox controller and computer keyboard
                        if (vectDir.x > -0.5 && vectDir.x < 0.5 && vectDir.y <= 1 && vectDir.y > 0)
                            lastRotation = 0;
                        else if (vectDir.x > -0.5 && vectDir.x < 0.5 && vectDir.y >= -1 && vectDir.y < 0)
                            lastRotation = 180;
                        else if (vectDir.x <= 1 && vectDir.x > 0 && vectDir.y > -0.5 && vectDir.y < 0.5)
                            lastRotation = 90;
                        else if (vectDir.x >= -1 && vectDir.x < 0 && vectDir.y > -0.5 && vectDir.y < 0.5)
                            lastRotation = -90;
                        else if (vectDir.x <= 1 && vectDir.x > 0.5 && vectDir.y <= 1 && vectDir.y > 0.5)
                            lastRotation = 45;
                        else if (vectDir.x <= 1 && vectDir.x > 0.5 && vectDir.y >= -1 && vectDir.y < -0.5)
                            lastRotation = 135;
                        else if (vectDir.x >= -1 && vectDir.x < -0.5 && vectDir.y <= 1 && vectDir.y > 0.5)
                            lastRotation = -45;
                        else if (vectDir.x >= -1 && vectDir.x < -0.5 && vectDir.y >= -1 && vectDir.y < -0.5)
                            lastRotation = -135;
                        transform.eulerAngles = new Vector3(lastRotation, 90, -90);

                        // player animation in network
                        if (vectDir != Vector3.zero) {
                            anim.SetBool("is_walking", true);
                        }
                        else {
                            anim.SetBool("is_walking", false);
                        }

                        //player synchronization network timer
                        resyncroTimer -= Time.fixedDeltaTime;
                        if (resyncroTimer <= 0) {
                            resyncro = true;
                            resyncroTimer = resyncroTimeDelay;
                        }

                        //synchronization condition to be always up to date
                        if (initSpawnPlayer < 10) {
                            // the first ten frame synchronization
                            rbody.MovePosition(selPos + rShip.position);
                            initSpawnPlayer++;
                        }
                        else if (resyncro) {
                            //timer to synchronize player network position
                            rbody.MovePosition(selPos + rShip.position);
                            resyncro = false;
                        }
                        else {
                            //smoothly movement network player
                            rbody.MovePosition(Vector3.MoveTowards(rbody.position, selPos + rShip.position,
                                Time.fixedDeltaTime * moveSpeed));
                        }

                        //
                        lastShipPosition = rShip.position;

                        if (!isOnShip) {
                            Debug.Log("!isOnShip");
                            rbody.MovePosition(selPos + rShip.position);
                        }
                    }
                }
            }

            // player names look in front of the camera
            if (Camera.main != null) {
                var fwd = Camera.main.transform.forward;
                pseudoTextMesh.transform.rotation = Quaternion.LookRotation(fwd);
            }
        }
    }

    /// <summary>
    /// checked if player is on ship
    /// if exit area then player go to init spawn
    /// </summary>
    /// <param name="other"> Area where a player can move</param>
    private void OnTriggerExit(Collider other) {
        if (other.Equals(GameObject.Find("zoneWhereMove").GetComponent<Collider>())) {
            isOnShip = false;
        }
    }

    /// <summary>
    /// checked if player is on ship
    /// if exit area then player go to initial spawn
    /// </summary>
    /// <param name="other"> Area where a player can move</param>
    private void OnTriggerEnter(Collider other) {
        if (other.Equals(GameObject.Find("zoneWhereMove").GetComponent<Collider>())) {
            isOnShip = true;
        }
    }

    /// <summary>
    /// is RPC method
    /// move the player to initial spawn
    /// </summary>
    [PunRPC]
    public void RespawnOtherPlayer() {
        rbody.MovePosition(selPos + rShip.position);
    }

    // 
    /// <summary>
    /// is RPC method
    /// player dash animation (not used)
    /// </summary>
    [PunRPC]
    public void SynchEndDashRPC() {
        anim.SetBool("is_dashing", false);
    }

    /// <summary>
    /// is RPC method
    /// synchronize dash player with all other player
    /// </summary>
    [PunRPC]
    public void SynchDashRPC(Vector3 moveVector) {
//        anim.SetBool("is_dashing", true);
        GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.Dash);
        Instantiate(particuleDash, transform.position, Quaternion.identity);
        if (photonView.isMine)
            rbody.velocity = moveVector.normalized * dashSpeed;
        else if (!photonView.isMine)
            rbody.velocity = moveVector.normalized * dashSpeed;
    }

    /// <summary>
    /// is RPC method
    /// idea of ​​optimizing the name of the player (not used)
    /// </summary>
    [PunRPC]
    public void SendNamePlayer(String namePlayer) {
        pseudoOnelinePlayer = namePlayer;
    }

    /// <summary>
    /// synchronization method used by PhotonView Object to send and receive network player information
    /// call foreach update frame to send new information
    /// </summary>
    /// <param name="stream"> Serialise network information </param>
    /// <param name="info">network information. for example the lag with timestamp value</param>
    /// <remarks>will be optimize</remarks>
    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (rbody != null) {
            if (stream.isWriting) {
                if (rShip != null) {
                    //get relative position to the ship
                    Vector3 position = rbody.position;
                    Vector3 positionInShip = position - rShip.position;

                    // create a floatlist information that will be serialized and simply send in a single package
                    float[] tabByte = {
                        positionInShip.x,
                        positionInShip.y,
                        positionInShip.z,
                        Input.GetAxisRaw("Horizontal"),
                        Input.GetAxisRaw("Vertical"),
                        GameManager.instance.PlayerManager.MyNbPlayer,
                        GameManager.instance.PlayerManager.Numbercolor
                    };
                    stream.SendNext(tabByte);

                    // i don't want change my string name player information in float value 
                    // because i not verify if all the information may be lost
                    // so i send another package with the player name information
                    stream.SendNext(GameManager.instance.PlayerManager.PseudoPlayerName);
                }
            }
            else {
                // recovery network information
                serialInfo = (float[]) stream.ReceiveNext();

                // update information
                //checked lag to init player direction an position
                vectDir = new Vector2(serialInfo[3], serialInfo[4]);
                float lag = Mathf.Abs((float) (PhotonNetwork.time - info.timestamp));
                selPos = new Vector3(serialInfo[0], serialInfo[1], serialInfo[2]);
                selPos += vectDir * lag;

                //init other information
                numOneLinePlayer = (int) serialInfo[5];
                colorOneLinePlayer = (int) serialInfo[6];

                pseudoOnelinePlayer = (String) stream.ReceiveNext();
            }
        }
    }

    /// <summary>
    /// give a new color on to the player instance
    /// </summary>
    /// <param name="numberColor"> color number reference</param>
    public void getColorOnPlayer(int numberColor) {
        float red_c = 1;
        float green_c = 1;
        float blue_c = 1;
        switch (numberColor) {
            case 0: //jaune
                red_c = 1f;
                green_c = 0.9852756f;
                blue_c = 0.06132078f;
                break;
            case 1: //rouge
                red_c = 0.8679245f;
                green_c = 0.1716046f;
                blue_c = 0.08597365f;
                break;
            case 2: //bleu
                red_c = 0.2231666f;
                green_c = 0.4444139f;
                blue_c = 0.8018868f;
                break;
            case 3: //vert
                red_c = 0.23713f;
                green_c = 0.745283f;
                blue_c = 0.2144446f;
                break;
            case 4: //pourpre
                red_c = 0.6509434f;
                green_c = 0.2364275f;
                blue_c = 0.391428f;
                break;
            case 5: //cyan
                red_c = 0.2216981f;
                green_c = 1f;
                blue_c = 0.9707254f;
                break;
            case 6: //violet
                red_c = 0.3098877f;
                green_c = 0.2460395f;
                blue_c = 0.5377358f;
                break;
            case 7: //marron
                red_c = 0.3962264f;
                green_c = 0.2185059f;
                blue_c = 0.1476504f;
                break;
            case 8: //blanc
                red_c = 1f;
                green_c = 0.9931791f;
                blue_c = 0.8443396f;
                break;
            case 9: //noir
                red_c = 0.1698113f;
                green_c = 0.1686499f;
                blue_c = 0.1465824f;
                break;
            default: //Defaut (blanc)
                red_c = 1f;
                green_c = 1f;
                blue_c = 1f;
                break;
        }

        Color colo_cire = new Color(red_c, green_c, blue_c);

        rendTextColor.material.SetColor("_Color", colo_cire);
    }
}