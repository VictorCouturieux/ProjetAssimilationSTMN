using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemyApparition : MonoBehaviour {

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hideAssetForOneSec());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator hideAssetForOneSec()
    {   
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.detectCollisions = false;

        MeshRenderer meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        yield return new WaitForSeconds(1);

        if(this.gameObject.name.Contains("Rock") || this.gameObject.name.Contains("Stone"))
        {
            meshRenderer.enabled = true;
        }

        rigidbody.detectCollisions = true;
    }
}
