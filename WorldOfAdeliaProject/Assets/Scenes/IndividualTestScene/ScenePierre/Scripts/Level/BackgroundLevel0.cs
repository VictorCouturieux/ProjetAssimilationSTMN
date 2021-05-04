using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLevel0 : MonoBehaviour
{
    private GameObject background;

    public List<GameObject> BigBackgroundObjectList = new List<GameObject>();
    public List<GameObject> SmallBackgroundObjectList = new List<GameObject>();
    public List<GameObject> CloudsBackgroundObjectList = new List<GameObject>();

    public GameObject BigPrefab1;
    public GameObject BigPrefab2;
    public GameObject BigPrefab3;
    public GameObject BigPrefab4;
    public GameObject BigPrefab5;

    public GameObject islandPrefab1;
    public GameObject islandPrefab2;
    public GameObject islandPrefab3;
    public GameObject islandPrefab4;
    public GameObject islandPrefab5;
    public GameObject islandPrefab6;
    public GameObject islandPrefab7;

    public GameObject cloudsPrefab1;
    public GameObject cloudsPrefab2;
    public GameObject cloudsPrefab3;
    public GameObject cloudsPrefab4;
    public GameObject cloudsPrefab5;

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background");

        BigBackgroundObjectList.Add(BigPrefab1);
        BigBackgroundObjectList.Add(BigPrefab2);
        BigBackgroundObjectList.Add(BigPrefab3);
        BigBackgroundObjectList.Add(BigPrefab4);
        BigBackgroundObjectList.Add(BigPrefab5);

        SmallBackgroundObjectList.Add(islandPrefab1);
        SmallBackgroundObjectList.Add(islandPrefab2);
        SmallBackgroundObjectList.Add(islandPrefab3);
        SmallBackgroundObjectList.Add(islandPrefab4);
        SmallBackgroundObjectList.Add(islandPrefab5);
        SmallBackgroundObjectList.Add(islandPrefab6);
        SmallBackgroundObjectList.Add(islandPrefab7);

        CloudsBackgroundObjectList.Add(cloudsPrefab1);
        CloudsBackgroundObjectList.Add(cloudsPrefab2);
        CloudsBackgroundObjectList.Add(cloudsPrefab3);
        CloudsBackgroundObjectList.Add(cloudsPrefab4);
        CloudsBackgroundObjectList.Add(cloudsPrefab5);


        GameObject bigObj = Instantiate(BigBackgroundObjectList[2], new Vector3(Random.Range(-70, -10), Random.Range(100, 150), 130), Quaternion.Euler(new Vector3(-90, 0, 0)));
        bigObj.transform.parent = background.transform;

        GameObject bigObj2 = Instantiate(BigBackgroundObjectList[3], new Vector3(Random.Range(10, 70), Random.Range(200, 250), 130), Quaternion.Euler(new Vector3(-90, 0, 0)));
        bigObj2.transform.parent = background.transform;

        GameObject smallObj = Instantiate(SmallBackgroundObjectList[5], new Vector3(Random.Range(-200, -100), Random.Range(100, 150), 117), Quaternion.Euler(new Vector3(0, 270, 90)));
        smallObj.transform.parent = background.transform;

        GameObject smallObj2 = Instantiate(SmallBackgroundObjectList[0], new Vector3(Random.Range(-50, -50), Random.Range(300, 400), 117), Quaternion.Euler(new Vector3(0, 270, 90)));
        smallObj2.transform.parent = background.transform;

        GameObject smallObj3 = Instantiate(SmallBackgroundObjectList[6], new Vector3(Random.Range(100, 200), Random.Range(500, 600), 103), Quaternion.Euler(new Vector3(0, 270, 90)));
        smallObj3.transform.parent = background.transform;

        GameObject cloudsObj = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(150, 250), Random.Range(200, 250), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj.transform.parent = background.transform;

        GameObject cloudsObj2 = Instantiate(CloudsBackgroundObjectList[0], new Vector3(Random.Range(-40, 40), Random.Range(500, 550), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj2.transform.parent = background.transform;

        GameObject cloudsObj3 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(-40, 40), Random.Range(850, 900), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj3.transform.parent = background.transform;

        GameObject cloudsObj4 = Instantiate(CloudsBackgroundObjectList[0], new Vector3(Random.Range(-40, 40), Random.Range(1100, 1200), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj4.transform.parent = background.transform;

        GameObject cloudsObj5 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(-350, -250), Random.Range(200, 250), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj5.transform.parent = background.transform;

        GameObject cloudsObj6 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(-550, -500), Random.Range(350, 300), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj6.transform.parent = background.transform;

        GameObject cloudsObj7 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(550, 500), Random.Range(350, 300), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj7.transform.parent = background.transform;

        GameObject cloudsObj8 = Instantiate(CloudsBackgroundObjectList[0], new Vector3(Random.Range(550, 500), Random.Range(560, 500), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj8.transform.parent = background.transform;

        GameObject cloudsObj9 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(-550, -500), Random.Range(560, 500), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj9.transform.parent = background.transform;

        GameObject cloudsObj10 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(700, 650), Random.Range(800, 700), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj8.transform.parent = background.transform;

        GameObject cloudsObj11 = Instantiate(CloudsBackgroundObjectList[2], new Vector3(Random.Range(-700, -650), Random.Range(800, 700), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj9.transform.parent = background.transform;

        GameObject cloudsObj12 = Instantiate(CloudsBackgroundObjectList[1], new Vector3(Random.Range(700, 650), Random.Range(1050, 900), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj8.transform.parent = background.transform;

        GameObject cloudsObj13 = Instantiate(CloudsBackgroundObjectList[2], new Vector3(Random.Range(-700, -650), Random.Range(1050, 900), 103), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudsObj9.transform.parent = background.transform;

        StartCoroutine(BigBackgroundObject());
        StartCoroutine(SmallBackgroundObject());
        StartCoroutine(CloudsBackgroundObject());
    }

    IEnumerator BigBackgroundObject()
    {
        yield return new WaitForSeconds(Random.Range(30, 45));
        int prefabIndex = UnityEngine.Random.Range(0, BigBackgroundObjectList.Count);
        GameObject bigObj = Instantiate(BigBackgroundObjectList[prefabIndex], new Vector3(Random.Range(-70, -10), Random.Range(1000, 1050), 120), Quaternion.Euler(new Vector3(-90, 0, 0)));
        bigObj.transform.parent = background.transform;

        yield return StartCoroutine(BigBackgroundObjectReset());

        yield return StartCoroutine(BigBackgroundObject());
    }

    IEnumerator BigBackgroundObjectReset()
    {
        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator SmallBackgroundObject()
    {
        yield return new WaitForSeconds(Random.Range(30, 50));
        int prefabIndex = UnityEngine.Random.Range(0, SmallBackgroundObjectList.Count);


        GameObject smallObj = Instantiate(SmallBackgroundObjectList[prefabIndex], new Vector3(-150, Random.Range(1050, 1200), 50), Quaternion.Euler(new Vector3(0, 270, 90)));
        smallObj.transform.parent = background.transform;
        smallObj.transform.localScale += new Vector3(4, 4, 4);


        if (Random.Range(0, 10) <= 6)
        {
            prefabIndex = UnityEngine.Random.Range(0, SmallBackgroundObjectList.Count);
            GameObject smallObj2 = Instantiate(SmallBackgroundObjectList[prefabIndex], new Vector3(Random.Range(50, 150), Random.Range(1200, 1250), 50), Quaternion.Euler(new Vector3(0, 270, 90)));
            smallObj2.transform.parent = background.transform;
        }
        else
        {
            prefabIndex = UnityEngine.Random.Range(0, SmallBackgroundObjectList.Count);
            GameObject smallObj2 = Instantiate(SmallBackgroundObjectList[prefabIndex], new Vector3(200, Random.Range(1200, 1250), 123), Quaternion.Euler(new Vector3(0, 270, 90)));
            smallObj2.transform.parent = background.transform;
            smallObj.transform.localScale += new Vector3(7, 7, 7);
        }


        yield return StartCoroutine(SmallBackgroundObjectReset());

        yield return StartCoroutine(SmallBackgroundObject());
    }

    IEnumerator SmallBackgroundObjectReset()
    {
        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator CloudsBackgroundObject()
    {
        yield return new WaitForSeconds(30);
        int prefabIndex = UnityEngine.Random.Range(0, CloudsBackgroundObjectList.Count);
        GameObject cloudObj = Instantiate(CloudsBackgroundObjectList[prefabIndex], new Vector3(Random.Range(-350, -250), Random.Range(1000, 1050), 105), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudObj.transform.parent = background.transform;

        prefabIndex = UnityEngine.Random.Range(0, CloudsBackgroundObjectList.Count);
        GameObject cloudObj4 = Instantiate(CloudsBackgroundObjectList[prefabIndex], new Vector3(Random.Range(250, 350), Random.Range(1000, 1050), 105), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudObj.transform.parent = background.transform;

        prefabIndex = UnityEngine.Random.Range(0, CloudsBackgroundObjectList.Count);
        GameObject cloudObj2 = Instantiate(CloudsBackgroundObjectList[prefabIndex], new Vector3(Random.Range(30, 70), Random.Range(1250, 1300), 105), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudObj2.transform.parent = background.transform;

        prefabIndex = UnityEngine.Random.Range(0, CloudsBackgroundObjectList.Count);
        GameObject cloudObj3 = Instantiate(CloudsBackgroundObjectList[prefabIndex], new Vector3(Random.Range(-20, 20), Random.Range(1400, 1450), 70), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudObj3.transform.parent = background.transform;

        yield return StartCoroutine(CloudsBackgroundObjectReset());

        yield return StartCoroutine(CloudsBackgroundObject());

    }

    IEnumerator CloudsBackgroundObjectReset()
    {
        yield return new WaitForSeconds(10f);

        int prefabIndex = UnityEngine.Random.Range(0, CloudsBackgroundObjectList.Count);
        GameObject cloudObj = Instantiate(CloudsBackgroundObjectList[prefabIndex], new Vector3(Random.Range(550, 600), Random.Range(1000, 1050), 105), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudObj.transform.parent = background.transform;

        prefabIndex = UnityEngine.Random.Range(0, CloudsBackgroundObjectList.Count);
        GameObject cloudObj2 = Instantiate(CloudsBackgroundObjectList[prefabIndex], new Vector3(Random.Range(550, 600), Random.Range(1000, 1050), 105), Quaternion.Euler(new Vector3(-90, 0, 0)));
        cloudObj2.transform.parent = background.transform;
    }
}
