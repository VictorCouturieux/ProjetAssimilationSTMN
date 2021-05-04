using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMogic : MonoBehaviour
{
//    public GameObject connectedMenu;

    public void disableMenuUI()
    {
//        connectedMenu.SetActive(false);
        PhotonNetwork.LoadLevel("LobbyCreatRoom");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
