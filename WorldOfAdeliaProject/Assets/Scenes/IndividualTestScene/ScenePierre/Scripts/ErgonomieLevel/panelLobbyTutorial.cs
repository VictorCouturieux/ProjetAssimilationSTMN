using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelLobbyTutorial : MonoBehaviour {
    public GameObject panelTutorial;

    PhotonView _view;

    void Start() {
    }

    private void OnTriggerEnter(Collider other) {
        if (panelTutorial.activeSelf == false) {
            if (other.GetType() == typeof(CapsuleCollider) || other.GetType() == typeof(BoxCollider)) {
                if (other.gameObject.GetComponent<PhotonView>().isMine) {
                    if (other.name.Contains("Player") || other.name.Contains("caisse")) {
                        panelTutorial.SetActive(true);
                    }
                }
                else {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (panelTutorial.activeSelf == true) {
            if (other.GetType() == typeof(CapsuleCollider) || other.GetType() == typeof(BoxCollider)) {
                if (other.gameObject.GetComponent<PhotonView>().isMine) {
                    if (other.name.Contains("Player") || other.name.Contains("caisse")) {
                        panelTutorial.SetActive(false);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}