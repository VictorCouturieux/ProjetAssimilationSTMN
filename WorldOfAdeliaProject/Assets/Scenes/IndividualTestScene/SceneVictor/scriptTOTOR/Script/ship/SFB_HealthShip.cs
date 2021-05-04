using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by COUTURIEUX VICTOR in collaboration with BILLAUD PIERRE
/// used to show everyone what is the current ship health 
/// </summary>
public class SFB_HealthShip : MonoBehaviour {
    
    /// <value>item list to show a ship health pictures </value>
    [SerializeField] private GameObject[] HPimages;

    // Start is called before the first frame update (not used)
    void Start() {
    }

    // 
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update() {
        // show current ship health 
        int hp = GameManager.instance.NetworkManager.ShipInstance.GetComponent<HealthScript>().hp;
        switch (hp) {
            case 0:
                HPimages[0].SetActive(false);
                HPimages[1].SetActive(false);
                HPimages[2].SetActive(false);
                HPimages[3].SetActive(false);
                break;
            case 1:
                HPimages[1].SetActive(false);
                HPimages[2].SetActive(false);
                HPimages[3].SetActive(false);
                break;
            case 2:
                HPimages[2].SetActive(false);
                HPimages[3].SetActive(false);
                break;
            case 3:
                HPimages[3].SetActive(false);
                break;
            default:
                break;
        }
    }
    
    /// <summary>
    /// used to lose ship health
    /// </summary>
    /// <param name="hp">current shit health</param>
    [PunRPC]
    public void decreaseHP(int hp) {
        //
        switch (hp) {
            case 0:
                HPimages[0].SetActive(false);
                HPimages[1].SetActive(false);
                HPimages[2].SetActive(false);
                HPimages[3].SetActive(false);
                break;
            case 1:
                HPimages[1].SetActive(false);
                HPimages[2].SetActive(false);
                HPimages[3].SetActive(false);
                break;
            case 2:
                HPimages[2].SetActive(false);
                HPimages[3].SetActive(false);
                break;
            case 3:
                HPimages[3].SetActive(false);
                break;
            default:
                break;
        }
    }
    
    /// <summary>
    /// synchronization method used by PhotonView Object to send and receive network player information
    /// call foreach update frame to send new information
    ///
    /// BUT is call to dodge Exception e method if the PhotonView element is empty
    /// </summary>
    /// <param name="stream"> Serialise network information </param>
    /// <param name="info">network information. for example the lag with timestamp value</param>
    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
    }
    
}