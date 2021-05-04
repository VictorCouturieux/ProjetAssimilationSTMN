using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestruction : MonoBehaviour
{
    PhotonView _view;

    // Start is called before the first frame update
    void Start()
    {
        _view = this.GetComponent<PhotonView>();
    }

    [PunRPC]
    private void destroyObject()
    {
        if (PhotonNetwork.isMasterClient)
        {
            _view.RPC("destroyObject", PhotonTargets.OthersBuffered);
        }
        //PhotonNetwork.Destroy(this.gameObject);
    }
}
