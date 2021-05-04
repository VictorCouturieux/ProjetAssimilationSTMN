using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSynchonisation : Photon.MonoBehaviour {
    public PhotonView photonView;
    
    public static List<GameObject> listGameObjToSyncho;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            
        }
        else {
            
        }
    }

    public static void addGameObjToList(GameObject gameObject) {
        listGameObjToSyncho.Add(gameObject);
    }
    
}
