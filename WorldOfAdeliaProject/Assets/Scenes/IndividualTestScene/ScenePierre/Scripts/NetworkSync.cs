using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSync : MonoBehaviour
{

    private Vector3 _correctPlayerPos;
    private Quaternion _correctPlayerRot;
    private PhotonView _view;

    // Start is called before the first frame update
    void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_view.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this._correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this._correctPlayerRot , Time.deltaTime * 5);
        }
    }

        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Debug.Log("OnPhotonSerializeView called : " + info);

        if (stream.isWriting)
        {
             stream.SendNext(transform.position);
             stream.SendNext(transform.rotation);
        } else
        {
            this._correctPlayerPos = (Vector3)stream.ReceiveNext();
            this._correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
       
    }

}
