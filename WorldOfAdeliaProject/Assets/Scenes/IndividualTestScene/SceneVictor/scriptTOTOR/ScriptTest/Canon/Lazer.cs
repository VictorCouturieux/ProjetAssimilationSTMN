using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    public float degat;
    
    public float timeToDestroyLayer = 3f;
    public float lazerSpeed = 20f;
    
    public Rigidbody2D rb;
    //---
    private double m_CreationTime;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * lazerSpeed;
    }

    private void OnCollisionEnter(Collision other1)
    {
        Destroy(gameObject);
//        Debug.Log("Lazer detruit");
    }

    // Update is called once per frame
    void Update() {
        float timePassed = (float) (PhotonNetwork.time - m_CreationTime);

//        Debug.Log(timeToDestroyLayer);
        if (timeToDestroyLayer < timePassed)
        {
            Destroy(gameObject);
        }
    }

    public void SetCreationTime(double creatTime) {
        m_CreationTime = creatTime;
    }
 
    
//    // Update is called once per frame
//    void Update()
//    {
//        timeToDestroyLayer -= Time.deltaTime;
//
////        Debug.Log(timeToDestroyLayer);
//        if (timeToDestroyLayer<0)
//        {
//            Destroy(gameObject);
////            Debug.Log("Lazer detruit");
//        }
//    }
   
    
}
