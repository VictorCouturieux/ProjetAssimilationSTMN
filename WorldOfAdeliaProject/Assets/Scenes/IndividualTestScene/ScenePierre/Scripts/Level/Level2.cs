using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    private string enemyFollowerPrefabName = "FollowerEnemy";
    private string enemyShooterPrefabName = "ShooterEnemy";
    private string enemyInvadersPrefabName = "MediumEnemy";

    public string RockPrefabName = "Rock";
    public string RockPrefabName2 = "Stone";

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-200, 200), Random.Range(1000, 1100), 0));

        Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-400, 400), Random.Range(800, 900), 0));

        //Level.instance.StartCoroutine(Level.instance.rockRandomApparition());
    }

    // Update is called once per frame
    void Update()
    {
        //Phase 1
        Level.instance.generateEnemy(1, 3, 1, enemyShooterPrefabName, new Vector3(-2, 10, -1), new Vector3(6, 0, 0), 7, 2);

        Level.instance.generateEnemy(2, 3, 1, enemyFollowerPrefabName, new Vector3(-20, 10, -5), new Vector3(40, 10, 0), 17, 2);

        Level.instance.generateEnemy(2, 3, 1, enemyShooterPrefabName, new Vector3(-3, 40, -1), new Vector3(6, 0, 0), 35, 2);

        Level.instance.generateEnemy(8, 2, 1, enemyInvadersPrefabName, new Vector3(-6, 20, 0), new Vector3((float)0.7, 0, 0), 45, 2);

        Level.instance.generateEnemy(8, 2, 1, enemyInvadersPrefabName, new Vector3(1, 20, 0), new Vector3((float)0.7, 0, 0), 51, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-50, 50, -5), new Vector3(20, Random.Range(2, 6), 0), 58, 2);

        Level.instance.generateEnemy(2, 3, 1, enemyFollowerPrefabName, new Vector3(-10, 10, -5), new Vector3(20, 10, 0), 67, 2);

        Level.instance.generateEnemy(3, 2, 1, enemyFollowerPrefabName, new Vector3(-3, 10, -5), new Vector3(3, 10, 0), 78, 2);

        Level.instance.generateEnemy(2, 2, 1, enemyShooterPrefabName, new Vector3(-3, 12, -1), new Vector3(12, 0, 0), 95, 2);

        Level.instance.generateEnemy(2, 3, 1, enemyFollowerPrefabName, new Vector3(-20, 10, -5), new Vector3(20, 10, 0), 106, 2);

        Level.instance.generateEnemy(4, 1, 1, enemyInvadersPrefabName, new Vector3(-4, 20, 0), new Vector3((float)0.7, 0, 0), 120, 2);

        Level.instance.generateEnemy(4, 1, 1, enemyInvadersPrefabName, new Vector3(4, 20, 0), new Vector3((float)0.7, 0, 0), 132, 2);

        timer += Time.deltaTime;

        if(timer >= 10)
        {
            timer = 0;
            if(Random.Range(0,10) <= 5)
            {
                Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-50, 50), 3000, 0), new Vector3 (0.01f,0.01f,0.01f));
            }
            else
            {
                Level.instance.generateRock(RockPrefabName2, new Vector3(Random.Range(-50, 50), 4000, 0), new Vector3(0.01f, 0.01f, 0.01f));
            }

            Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-50, 50), 6000, 0), new Vector3(0, 0, 0));
        }

        Level.instance.endWinLevel(Level.instance.levelDuration);
    }
}
