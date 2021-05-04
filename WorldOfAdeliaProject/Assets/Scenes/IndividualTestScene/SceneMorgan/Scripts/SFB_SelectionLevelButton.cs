using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionLevelButton : MonoBehaviour
{

    public GameObject cursorLevel;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        if (cursorLevel)
        {
            anim = cursorLevel.GetComponent<Animation>();
        }
    }

    public void OnMainMenu() {
        SceneManager.LoadScene(GameManager.nameSceneMainMenuToLoad);
        PhotonNetwork.Disconnect();
    }
    
    public void JoinLevel0()
    {
        if (PhotonNetwork.isMasterClient)
        {
            StartCoroutine(joinLevel0());
        }
    }

    public void JoinLevel1()
    {
        if (PhotonNetwork.isMasterClient) {
            StartCoroutine(joinLevel1());
        }
    }

    public void JoinLevel2()
    {
        if (PhotonNetwork.isMasterClient) {
            StartCoroutine(joinLevel2());
        }
    }

    public void ReturnToLobby()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                AllReturnLobby();
            }
            else
            {
                GetComponent<PhotonView>().RPC("AllReturnLobby", PhotonTargets.All);
            }
        }
    }

    public IEnumerator joinLevel0()
    {
        if (anim && cursorLevel)
        {
            moveShipToLevel("MoveToLevel0");
        }
        yield return new WaitForSeconds(3);
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                AllJoinLevel0();
            }
            else
            {
                GetComponent<PhotonView>().RPC("AllJoinLevel0", PhotonTargets.All);
            }
        }
    }

    public IEnumerator joinLevel1()
    {
        if (anim && cursorLevel)
        {
            moveShipToLevel("MoveToLevel1");
        }
        yield return new WaitForSeconds(3);
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                AllJoinLevel1();
            }
            else
            {
                GetComponent<PhotonView>().RPC("AllJoinLevel1", PhotonTargets.All);
            }
        }
    }

    public IEnumerator joinLevel2()
    {
        if (anim && cursorLevel)
        {
            moveShipToLevel("MoveToLevel2");
        }
        yield return new WaitForSeconds(3);
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                AllJoinLevel2();
            }
            else
            {
                GetComponent<PhotonView>().RPC("AllJoinLevel2", PhotonTargets.All);
            }
        }
    }


    [PunRPC]
    public void AllReturnLobby()
    {
        Debug.Log("ReturnToLobby");
        GameManager.instance.NetworkManager.moveSceneLobby();
    }

    [PunRPC]
    public void AllJoinLevel0()
    {
        GameManager.instance.NetworkManager.moveSceneLevel0();
        Debug.Log("we are connected to the room GAME!");
    }

    [PunRPC]
    public void AllJoinLevel1()
    {
        GameManager.instance.NetworkManager.moveSceneLevel1();
        Debug.Log("we are connected to the room GAME!");
    }

    [PunRPC]
    public void AllJoinLevel2()
    {
        GameManager.instance.NetworkManager.moveSceneLevel2();
        Debug.Log("we are connected to the room GAME!");
    }

    public void moveShipToLevel(string moveToLevel)
    {
        if (PhotonNetwork.offlineMode)
        {
            anim.Play(moveToLevel);
        }
        else
        {
            GetComponent<PhotonView>().RPC("animShipLevel", PhotonTargets.All, moveToLevel);
        }
    }

    [PunRPC]
    public void animShipLevel(string moveToLevel)
    {
        anim.Play(moveToLevel);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}