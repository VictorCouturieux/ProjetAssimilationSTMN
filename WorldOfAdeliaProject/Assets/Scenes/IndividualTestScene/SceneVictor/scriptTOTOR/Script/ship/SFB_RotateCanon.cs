using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

/// <summary>
/// Created by COUTURIEUX VICTOR 
/// used in specific ship button to adjust the cannons rotation 
/// </summary>
public class SFB_RotateCanon : MonoBehaviour {
    /// <value>Cannon instance</value>
    public GameObject canon;

    /// <value> Cannon rotation center </value>
    public GameObject centreRotation;

    /// <value>Cannon rotation speed</value>
    public static int rotationSpeed = 30;

    /// <value>if is left ship cannon</value>
    public bool isLeft = true;

    /// <value> cannon rotational direction can be clockwise </value>
    public bool isClockwise;

    /// <value> limite cannon rotational direction </value>
    public float limite;

    /// <value> cannon rotational direction is turning</value>
    private bool isWorks = false;

    /// <summary>
    /// if a player use the button then the cannon is turning
    /// </summary>
    /// <param name="other">cannon rotational direction user</param>
    private void OnTriggerEnter(Collider other) {
        if (other.GetType() == typeof(CapsuleCollider) || other.GetType() == typeof(BoxCollider)) {
            if (other.name.Contains("Player") || other.name.Contains("caisse")) {
                if (!isWorks) {
                    isWorks = true;
                }

//                Debug.Log("OnTriggerEnter");
            }
        }
    }

    /// <summary>
    /// if a player leave the button then the cannon isn't turning
    /// </summary>
    /// <param name="other">cannon rotational direction user</param>
    private void OnTriggerExit(Collider other) {
        if (other.GetType() == typeof(CapsuleCollider) || other.GetType() == typeof(BoxCollider)) {
            if (other.name.Contains("Player") || other.name.Contains("caisse")) {
                if (isWorks) {
                    isWorks = false;
                }

//                Debug.Log("OnTriggerExit");
            }
        }
    }

    /// <summary>
    /// FixedUpdate() has the frequency of the physics system; it is called every fixed frame-rate frame.
    /// </summary>
    /// <remarks>
    /// turn the cannon depending condition values 
    /// </remarks>
    private void FixedUpdate() {
        if (isWorks) {
            if (isClockwise) {
//                Debug.Log("Non horraire : z=" + canon.transform.rotation.z + ", x=" + canon.transform.rotation.x);
                if (isLeft) {
                    if (canon.transform.rotation.z <= limite) {
                        Vector3 vct = new Vector3(
                            centreRotation.transform.position.x,
                            centreRotation.transform.position.y,
                            centreRotation.transform.position.z
                        );
                        canon.transform.RotateAround(vct, Vector3.back, rotationSpeed * Time.fixedDeltaTime);
                    }
                }
                else {
                    if (canon.transform.rotation.x <= limite) {
                        Vector3 vct = new Vector3(
                            centreRotation.transform.position.x,
                            centreRotation.transform.position.y,
                            centreRotation.transform.position.z
                        );
                        canon.transform.RotateAround(vct, Vector3.back, rotationSpeed * Time.fixedDeltaTime);
                    }
                }
            }
            else {
//                Debug.Log("horraire : z=" + canon.transform.rotation.z + ", x=" + canon.transform.rotation.x);
                if (isLeft) {
                    if (canon.transform.rotation.z >= limite) {
                        Vector3 vct = new Vector3(
                            centreRotation.transform.position.x,
                            centreRotation.transform.position.y,
                            centreRotation.transform.position.z
                        );
                        canon.transform.RotateAround(vct, Vector3.back, -rotationSpeed * Time.fixedDeltaTime);
                    }
                }
                else {
                    if (canon.transform.rotation.x >= limite) {
                        Vector3 vct = new Vector3(
                            centreRotation.transform.position.x,
                            centreRotation.transform.position.y,
                            centreRotation.transform.position.z
                        );
                        canon.transform.RotateAround(vct, Vector3.back, -rotationSpeed * Time.fixedDeltaTime);
                    }
                }
            }
        }
    }

    // Update is called once per frame (not used)
    void Update() {
    }
}