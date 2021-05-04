using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRockScript : MonoBehaviour
{
    int random;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (random < 33)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 50, 0, 0));
        }
        else if (random >= 33 && random <= 66)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
        }
        else if (random >= 67)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * 50));
        }
    }
}
