using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Created by COUTURIEUX VICTOR 
/// used in specific ship button to shoot with the cannons
/// </summary>
/// <remarks>
/// In the first version of adelia, cannonballs was lasers
/// Can be optimised
/// </remarks>
public class SFB_ShooterFireCanon : MonoBehaviour {
    /// <value>benchmark of cannonballs spawn </value>
    public Transform shooterRefPoint;

    /// <value> cannonballs prefab that would be spawned</value>
    public GameObject LazerGameObject;

    /// <value>cannonballs move speed</value>
    public float lazerSpeed = 5;

    /// <value>cannonballs rate of fire</value>
    public float rateIntitLazer = 0.5f;

    /// <value>cannon is shooting</value>
    private bool isWorks = false;

    /// <value>last rate of fire timer</value>
    private float m_LastShootTime;

    /// <value>last projectiles identifying</value>
    private int m_LastProjectileId;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        shooterRefPoint.transform.Rotate(0, 180, 0);
    }

    /// <summary>
    /// if a player use the button then you start the timer to shoot a cannonball
    /// </summary>
    /// <param name="other">cannon rotational direction user</param>
    private void OnTriggerEnter(Collider other) {
        if (other.GetType() == typeof(CapsuleCollider) || other.GetType() == typeof(BoxCollider)) {
            if (other.name.Contains("Player")) {
                isWorks = true;
                m_LastShootTime = rateIntitLazer;
            }
        }
    }

    /// <summary>
    /// if a player leave the button then stop the timer to shoot a cannonball
    /// </summary>
    /// <param name="other">cannon rotational direction user</param>
    private void OnTriggerExit(Collider other) {
        if (other.GetType() == typeof(CapsuleCollider) || other.GetType() == typeof(BoxCollider)) {
            if (other.name.Contains("Player")) {
                isWorks = false;
            }
        }
    }

    /// <summary>
    /// FixedUpdate() has the frequency of the physics system; it is called every fixed frame-rate frame.
    /// </summary>
    /// <remarks>
    /// shoot cannonball if the time is work
    /// </remarks>
    void FixedUpdate() {
        if (isWorks) {
            UpdateShooting();
        }
    }

    /// <summary>
    /// the cannon is shooting
    /// </summary>
    /// <remarks>
    /// checked if all network reference is Ok
    /// </remarks>
    void UpdateShooting() {
        if (!GetComponent<PhotonView>().isMine)
            return;
        if (Time.realtimeSinceStartup - m_LastShootTime < rateIntitLazer)
            return;

        m_LastProjectileId++;

        if (PhotonNetwork.offlineMode) {
            OnShoot(m_LastProjectileId, new PhotonMessageInfo());
        }
        else {
            GetComponent<PhotonView>().RPC("OnShoot", PhotonTargets.All, m_LastProjectileId);
        }
    }

    /// <summary>
    /// is RPC method
    /// synchronize cannonballs rate of fire timer and position
    ///     with all other player when shooter player is on button
    /// </summary>
    /// <param name="projectileId">rate of fire timer</param>
    /// <param name="info">network information. for example the lag with timestamp value</param>
    [PunRPC]
    public void OnShoot(int projectileId, PhotonMessageInfo info) {
        double timeStamp = PhotonNetwork.time;
        if (!info.Equals(new PhotonMessageInfo())) {
            timeStamp = info.timestamp;
        }

        CreatPojectile(timeStamp);
    }

    /// <summary>
    /// method to creat a new cannonballs
    /// </summary>
    /// <param name="createTime">rate of fire timer</param>
    public void CreatPojectile(double createTime) {
        m_LastShootTime = Time.realtimeSinceStartup;
        //play sound effect of cannonball shooting
        GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(),
            SFB_SoundManager.SoundFX.ShootingCannon);

        //instancate new cannonball
        GameObject newProjectileObject = Instantiate(Resources.Load<GameObject>(LazerGameObject.name),
            shooterRefPoint.position,
            shooterRefPoint.rotation
        );

        // send timer information to the ShotScript.cs created by BILLAUD PIERRE
        ShotScript newShot = newProjectileObject.GetComponent<ShotScript>();
        newShot.SetCreationTime(createTime);
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