using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInvadersScript : MonoBehaviour
{
    private Transform enemyHolder;
    public Transform enemyPrefab;
    public float speed;
    public double fireRate = 0.997;
    private bool hasSpawn;
    Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        hasSpawn = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.01f);
        enemyHolder = GetComponent<Transform>();
    }

    void Update()
    {
        if (hasSpawn == false)
        {
            if (objectRenderer.IsVisibleFrom(Camera.main))
            {
                hasSpawn = true;
            }
        }

        if (hasSpawn == true)
        {
            if ((objectRenderer.IsVisibleFrom(Camera.main)) == false)
            {
                DestroyImmediate(gameObject);
            }
        }
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            enemyHolder.position += Vector3.right * speed;

            if (enemyHolder.position.x< -8 || enemyHolder.position.x > 4)
            {  
                speed = -speed;
                enemyHolder.position += Vector3.down * 1f;
                return;
            }
        }

        if(enemyHolder.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
