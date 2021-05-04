using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackgroundObj : MonoBehaviour
{
    private GameObject target;
    private Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(designTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform)
        {
            if(this.gameObject.transform.position.y < targetTransform.position.y-200)
                {
                    Destroy(this.gameObject);
                }
        }

    }

    IEnumerator designTarget()
    {
        yield return new WaitForSeconds(1f);

        target = GameObject.Find("Ship(Clone)");
        if (target)
        {
            targetTransform = target.GetComponent<Transform>();
        }
    }
}
