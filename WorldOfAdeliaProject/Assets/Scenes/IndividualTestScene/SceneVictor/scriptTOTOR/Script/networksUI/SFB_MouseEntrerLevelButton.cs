using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by COUTURIEUX VICTOR in collaboration with BUCHER MORGAN
/// used to show everyone what is level chose by the master player
/// </summary>
/// <remarks>
/// can be optimized
/// </remarks>
public class SFB_MouseEntrerLevelButton : MonoBehaviour {
    /// <value>
    /// Graphic items (elements) list to display when mouse of the master player is on specific zone
    /// </value>
    public GameObject[] ShowElements;

    /// <value>
    /// current button of this script
    /// </value>
    public ButtonLevel _ButtonLevel;

    /// <value>
    /// all specific button enumeration
    /// </value>
    public enum ButtonLevel {
        ReturnLobby,
        Level0,
        Level1,
        Level2
    }

    // Start is called before the first frame update (not use)
    void Start() {
    }

    /// <summary>
    /// call when mouse enter in the button to chose a level or go back to lobbyShip
    /// </summary>
    public void mMouseEnter() {
        if (PhotonNetwork.isMasterClient) {
            switch (_ButtonLevel) {
                case ButtonLevel.ReturnLobby:
                    if (PhotonNetwork.offlineMode) {
                        ActiveElement(0);
                    }
                    else {
                        GetComponent<PhotonView>().RPC("ActiveElement", PhotonTargets.All, 0);
                    }

                    break;
                case ButtonLevel.Level0:
                    if (PhotonNetwork.offlineMode) {
                        ActiveElement(1);
                    }
                    else {
                        GetComponent<PhotonView>().RPC("ActiveElement", PhotonTargets.All, 1);
                    }

                    break;
                case ButtonLevel.Level1:
                    if (PhotonNetwork.offlineMode) {
                        ActiveElement(2);
                    }
                    else {
                        GetComponent<PhotonView>().RPC("ActiveElement", PhotonTargets.All, 2);
                    }

                    break;
                case ButtonLevel.Level2:
                    if (PhotonNetwork.offlineMode) {
                        ActiveElement(3);
                    }
                    else {
                        GetComponent<PhotonView>().RPC("ActiveElement", PhotonTargets.All, 3);
                    }

                    break;
                default:
//                    Debug.Log("");
                    break;
            }
        }
    }

    /// <summary>
    /// is RPC method call when mouse of the master player is on specific zone
    /// to show specific item (element)
    /// </summary>
    /// <param name="numElement">list number of the specific item (element)</param>
    [PunRPC]
    private void ActiveElement(int numElement) {
//        Debug.Log("ActiveElement");
        foreach (GameObject element in ShowElements) {
            element.SetActive(false);
        }

        ShowElements[numElement].SetActive(true);
    }

    // Update is called once per frame
    void Update() {
    }
}