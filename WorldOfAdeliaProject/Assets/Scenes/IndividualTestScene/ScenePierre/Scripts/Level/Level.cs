using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public static Level instance = null;

    bool rockIsAppeared = false;
    bool enemyIsAppeared = false;
    public float levelDuration;

    private GameObject middleground;
    private GameObject background;

    public GameObject enemyFollowerPrefab;
    public GameObject enemyShootingPrefab;
    public GameObject enemyMediumPrefab;

    public GameObject RockPrefab;
    public GameObject RockPrefab2;

    public GameObject winPanel;
    public GameObject gameOverPanel;


    public void Awake()
    {
        instance = this;
        middleground = GameObject.Find("Middleground");
        background = GameObject.Find("Background1");
    }

    public IEnumerator rockRandomApparition()
    {
        if (PhotonNetwork.isMasterClient)
        {
            yield return new WaitForSeconds(Random.Range(8, 12));

            if ((Random.Range(5, 10)) <= 7)
            {

                float boatPositionX = GameObject.Find("Ship(Clone)").transform.position.x;
                GameObject rock = PhotonNetwork.InstantiateSceneObject(RockPrefab.name, new Vector3(boatPositionX, Random.Range(150, 200), 0), Quaternion.identity, 0, null);
                rock.transform.parent = middleground.transform;
            }
            else
            {
                GameObject rock1 = PhotonNetwork.InstantiateSceneObject(RockPrefab.name, new Vector3(Random.Range(-10, 10), Random.Range(300, 40), 0), Quaternion.identity, 0, null);
                rock1.transform.parent = middleground.transform;
            }

            if ((Random.Range(0, 10)) > 7)
            {
                GameObject rock2 = PhotonNetwork.InstantiateSceneObject(RockPrefab2.name, new Vector3(Random.Range(-40, 40), Random.Range(200, 300), 0), Quaternion.identity, 0, null);
                rock2.transform.parent = middleground.transform;
            }

            yield return StartCoroutine(rockRandomApparitionReset());

            yield return StartCoroutine(rockRandomApparition());
        }
    }

    public IEnumerator rockRandomApparitionReset()
    {
        yield return new WaitForSeconds(2.5f);
    }

    public void generateEnemy(int numberOfEnemies, int healthPoint, float speed, string enemyName, Vector3 vectorApparition, Vector3 vectorSorting, float time, float timeToAppearAgain, Vector3 scale = default(Vector3))
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (Timer.Instance.Time() > time && Timer.Instance.Time() < time + 1.5)
            {
                if (!enemyIsAppeared)
                {
                    for (int i = 0; i < numberOfEnemies; i++)
                    {
                        if (!vectorApparition.Equals(null) && !vectorSorting.Equals(null))
                        {
                            GameObject enemy = PhotonNetwork.InstantiateSceneObject(enemyName, vectorApparition + i * vectorSorting, Quaternion.identity, 0, null);
                            enemy.transform.parent = middleground.transform;

                            if(enemyName == "MediumEnemy")
                            {
                                GameObject enemy2 = PhotonNetwork.InstantiateSceneObject(enemyName, vectorApparition + i * vectorSorting + new Vector3(0,1,0), Quaternion.identity, 0, null);
                                enemy2.transform.parent = middleground.transform;
                            }

                            if(scale != null)
                            {
                                enemy.transform.localScale += scale;
                            }

                            HealthScript health = enemy.gameObject.GetComponent<HealthScript>();
                            if (health != null)
                            {
                                if (health.maxHp != null)
                                {
                                    health.maxHp = healthPoint;
                                    health.hp = health.maxHp;
                                }
                            }
                        }
                    }

                    enemyIsAppeared = true;
                    StartCoroutine(enemyApparitionIsReset(timeToAppearAgain));
                }
            }
        }
    }

    public void generateRock(string rockName, Vector3 vectorApparition, Vector3 scale = default(Vector3))
    {
        if (PhotonNetwork.isMasterClient)
        {
            GameObject rock = PhotonNetwork.InstantiateSceneObject(rockName, new Vector3(Random.Range(-10, 10), Random.Range(5, 55), 0), Quaternion.identity, 0, null);
            rock.transform.parent = middleground.transform;

            if (scale != null)
            {
                rock.transform.localScale += scale;
            }

        }
    }

    public void generateRockLevel(string rockName, Vector3 vectorApparition, float time, float timeToAppearAgain, Vector3 scale = default(Vector3))
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (Timer.Instance.Time() > time && Timer.Instance.Time() < time + 1.5)
            {
                if (!rockIsAppeared)
                {
                    GameObject rock = PhotonNetwork.InstantiateSceneObject(rockName, vectorApparition, Quaternion.identity, 0, null);
                    rock.transform.parent = middleground.transform;

                    if (scale != null)
                    {
                        rock.transform.localScale += scale;
                    }
                    rockIsAppeared = true;
                    StartCoroutine(rockApparitionIsReset(timeToAppearAgain));
                }
            }
        }
    }

    public IEnumerator enemyApparitionIsReset(float timeToAppearAgain)
    {
        yield return new WaitForSeconds(timeToAppearAgain);
        enemyIsAppeared = false;
    }

    public IEnumerator rockApparitionIsReset(float timeToAppearAgain)
    {
        yield return new WaitForSeconds(timeToAppearAgain);
        rockIsAppeared = false;
    }

    public void endWinLevel(float time)
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (Timer.Instance.Time() > time && Timer.Instance.Time() < time + 1.5)
            {
                StartCoroutine(win());
            }
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

    public void setSpeedBackgroundToNormal()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                speedBackgroundForAll(new Vector2(1, 5));
            }
            else
            {
                GetComponent<PhotonView>().RPC("speedBackgroundForAll", PhotonTargets.All, new Vector2(1, 5));
            }
        }
    }

    public void setSpeedBackgroundToFast()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                speedBackgroundForAll(new Vector2(1, 20));
            }
            else
            {
                GetComponent<PhotonView>().RPC("speedBackgroundForAll", PhotonTargets.All, new Vector2(1, 20));
            }
        }
    }

    public void setSpeedBackgroundToVeryFast()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                speedBackgroundForAll(new Vector2(1, 40));
            }
            else
            {
                GetComponent<PhotonView>().RPC("speedBackgroundForAll", PhotonTargets.All, new Vector2(1, 40));
            }
        }
    }

    [PunRPC]
    public void speedBackgroundForAll(Vector2 vitesse)
    {
        ScrollingScript.instance.speed = vitesse;
    }

    [PunRPC]
    public void AllReturnLobby()
    {
        GameManager.instance.NetworkManager.moveSceneLobby();
    }

    public void callToDisplayLose()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                displayLose();
            }
            else
            {
                GetComponent<PhotonView>().RPC("displayLose", PhotonTargets.All);
            }
        }
    }

    [PunRPC]
    public void displayLose()
    {
        gameOverPanel.SetActive(true);
        GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.GameOver);
    }

    public void callToDisplayWin()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                displayWin();
            }
            else
            {
                GetComponent<PhotonView>().RPC("displayWin", PhotonTargets.All);
            }
        }
    }

    [PunRPC]
    public void displayWin()
    {
        winPanel.SetActive(true);
        GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.Win);
    }

    IEnumerator lose()
    {
        callToDisplayLose();

        yield return new WaitForSeconds(5);
        ReturnToLobby();
    }

    IEnumerator win()
    {
        callToDisplayWin();
        yield return new WaitForSeconds(5);
        ReturnToLobby();
    }

    public void endLoseLevel()
    {
        if (PhotonNetwork.isMasterClient)
        {
            StartCoroutine(lose());
        }
    }
}
