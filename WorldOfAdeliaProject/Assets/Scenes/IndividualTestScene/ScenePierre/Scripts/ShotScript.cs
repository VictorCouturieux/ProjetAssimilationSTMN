using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Comportement des tirs
/// </summary>
public class ShotScript : MonoBehaviour
{
     
    // 1 - Designer variables
     //dffds
    /// <summary>
    /// Points de dégâts infligés
    /// </summary>
    public int damage = 1;
    public Rigidbody rb;
    public float lazerSpeed = 5f;
    public GameObject explosionEffect;
    
    public float timeToDestroyLayer = 3f;
    //---
    private double m_CreationTime;
    
    /// <summary>
    /// Projectile ami ou ennemi ?
    /// </summary>
    public bool isEnemyShot = false;

    void Start()
    {
        rb.velocity = transform.right * lazerSpeed;
        // 2 - Destruction programmée
//        Destroy(gameObject, 20); // 20sec
    }
    
    // Update is called once per frame
    void Update() {
        float timePassed = (float) (PhotonNetwork.time - m_CreationTime);

//        Debug.Log(timeToDestroyLayer);
        if (timeToDestroyLayer < timePassed)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other1)
    {
        Explode();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (SceneManager.GetActiveScene().name == GameManager.nameSceneLobbyShipToLoad) {
            if (other.CompareTag("DecorTag")) {
                Explode();
                Destroy(gameObject);
            }
        }
    }

    public void SetCreationTime(double creatTime) {
        m_CreationTime = creatTime;
    }

    public void Explode()
    {
        Instantiate(explosionEffect,transform.position, transform.rotation);
    }
}
