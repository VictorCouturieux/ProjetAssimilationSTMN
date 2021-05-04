using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localTimer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        if (t >= 180)
        {
            timerText.color = Color.yellow;
            timerText.text = "3:00 / 3:00";
        }
        else
        {
            string minutes = ((int)t / 60).ToString();
            string seconds = ((int)t % 60).ToString();

            if( ((int)t % 60) < 10) 
            {
                timerText.text = minutes + ":" + "0" + seconds + " / 3:00";
            }
            else
            {
                timerText.text = minutes + ":" + seconds +" / 3:00";
            } 
        }      
    }
}
