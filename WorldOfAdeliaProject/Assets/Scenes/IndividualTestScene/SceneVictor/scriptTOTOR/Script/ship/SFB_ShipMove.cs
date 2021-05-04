using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Created by COUTURIEUX VICTOR 
/// used in specific ship button to checked the lateral movement function of ship is used
/// </summary>
public class SFB_ShipMove : MonoBehaviour {
    /// <value>is already used</value>
    private bool isTrygger;

    public bool IsTrygger {
        get { return isTrygger; }
        set { isTrygger = value; }
    }

    /// <value>the driver player on this button</value>
    private Collider driver;

    public Collider Driver {
        get { return driver; }
    }

    /// <value>ship instance position</value>
    public GameObject Ship;

    public Rigidbody rShip;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        isTrygger = false;
    }

    /// <summary>
    /// if a player use the button then the button is used and the driver is instantiate
    /// </summary>
    /// <param name="other">ship driver collider</param>
    private void OnTriggerEnter(Collider other) {
        if (SceneManager.GetActiveScene().name != GameManager.nameSceneLobbyShipToLoad) {
            if (other.GetType() == typeof(CapsuleCollider)) {
                if (other.name.Contains("Player")) {
                    if (driver == null) {
                        driver = other;
                        isTrygger = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// if a player leave the button then the button is not used and the driver is null
    /// </summary>
    /// <param name="other">ship driver collider</param>
    private void OnTriggerExit(Collider other) {
        if (SceneManager.GetActiveScene().name != GameManager.nameSceneLobbyShipToLoad) {
            if (other.GetType() == typeof(CapsuleCollider)) {
                if (other.name.Contains("Player")) {
                    if (driver == other) {
                        driver = null;
                        isTrygger = false;

                        if (GameManager.instance.PlayerManager.MyPlayerInstance
                                .GetComponent<Collider>() == other) {
                            //synchronize ship position with RPC method
                            Ship.GetComponent<SFB_ShipStatement>().SyncroPosition(rShip.position);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame (not used)
    void Update() {
    }
}