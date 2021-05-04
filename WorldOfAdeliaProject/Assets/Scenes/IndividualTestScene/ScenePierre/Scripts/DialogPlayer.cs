using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPlayer : MonoBehaviour
{
    public GameObject bubbleDialog;

    // Start is called before the first frame update
    void Start()
    {
        bubbleDialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            bubbleDialog.SetActive(true);
            StartCoroutine(destroyMessage());
        }
    }

    IEnumerator destroyMessage()
    {
        yield return new WaitForSeconds(2);
        bubbleDialog.SetActive(false);
    }
}
