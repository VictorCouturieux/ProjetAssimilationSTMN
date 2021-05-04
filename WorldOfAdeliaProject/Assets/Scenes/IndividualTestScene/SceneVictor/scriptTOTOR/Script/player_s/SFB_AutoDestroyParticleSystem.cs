using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// team communication error :
/// BILLAUD PIERRE had create a same class for its use.
/// used to destroy the gameObject of particle system on the 'dash player' function of control after its effect.
/// </summary>
public class SFB_AutoDestroyParticleSystem : MonoBehaviour {
    /// <value> particles system instance of game object</value>
    private ParticleSystem ps;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update() {
        if (ps) {
            if (!ps.IsAlive()) {
                Destroy(gameObject);
            }
        }
    }
}