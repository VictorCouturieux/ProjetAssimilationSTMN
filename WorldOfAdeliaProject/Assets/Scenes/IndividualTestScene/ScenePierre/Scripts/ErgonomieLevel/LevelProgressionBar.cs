using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelProgressionBar : MonoBehaviour
{
    public Image foregroundImage;
    public Image cursor;
    private float maxTime = 180;
    private float speed;
    float timeLeft;
    private float startTime;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        foregroundImage = GetComponent<Image>();
        timeLeft = maxTime;
        speed = foregroundImage.GetComponent<RectTransform>().sizeDelta.y / maxTime;
    }

    // Update is called once per frame
    void Update()
    {
      if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            foregroundImage.fillAmount = timeLeft / maxTime;

            if(timeLeft > maxTime*0.02)
            {
                cursor.transform.position += new Vector3(0, speed*Time.deltaTime,0);
            }
        }
    }
}
