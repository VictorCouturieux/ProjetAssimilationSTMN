using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouch : MonoBehaviour {
    public bool isEnemyShot = true;
    public int damage = 1;

    private void OnTriggerEnter(Collider other) {
        if (PhotonNetwork.isMasterClient) {
            HealthScript health = this.gameObject.GetComponent<HealthScript>();
            if(health != null)
            {
                if (health.hp <= 0)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
            }
        }
    }
}