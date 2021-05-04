using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class Level0 : UnityEngine.MonoBehaviour
{
    public string enemyFollowerPrefabName = "FollowerEnemy";
    public string enemyShooterPrefabName = "ShooterEnemy";
    public string enemyInvadersPrefabName = "MediumEnemy";

    public string RockPrefabName = "Rock";
    public string RockPrefabName2 = "Stone";

    void Start()
    {
        Level.instance.generateRock(RockPrefabName, new Vector3(-50, Random.Range(2200, 2400), 0));

        //Level.instance.generateRock(RockPrefabName, new Vector3(300, Random.Range(1900, 2000),0));

        Level.instance.generateRock(RockPrefabName, new Vector3(-300, Random.Range(2200, 2400),0));

        Level.instance.generateRock(RockPrefabName2, new Vector3(300, 2500, 0));

        Level.instance.StartCoroutine(Level.instance.rockRandomApparition());
        
    }

    void Update()
    {
        //Phase 1
        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-2, Random.Range(5, 10), -5), new Vector3(5, Random.Range(2, 6), 0), 12, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-10, Random.Range(50,55), -5), new Vector3(5, Random.Range(10, 6), 0), 14, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-10, 150, -5), new Vector3(5, Random.Range(10, 6), 0), 16, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-200, 100, -5), new Vector3(200, Random.Range(2, 6), 0), 20, 2);

        Level.instance.generateEnemy(2, 3, 1, enemyFollowerPrefabName, new Vector3(-50, 125, -5), new Vector3(250, Random.Range(2, 6), 0), 25, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(-20, 10, -5), new Vector3(250, 10, 0), 30, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(20, 20, -5), new Vector3(250, 10, 0), 40, 2);

        Level.instance.generateEnemy(8, 1, 1, enemyInvadersPrefabName, new Vector3(0, 5, 0), new Vector3((float)0.7, 0, 0), 50, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-50, 50, -5), new Vector3(20, Random.Range(2, 6), 0), 57, 2);

        //Phase 2

        Level.instance.generateEnemy(8, 1, 1, enemyInvadersPrefabName, new Vector3(0, 5, 0), new Vector3((float)0.7, 0, 0), 70, 2);

        Level.instance.generateEnemy(1, 1, 1, enemyFollowerPrefabName, new Vector3(-20, 5, -5), new Vector3(20, 10, 0), 78, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(20, 5, -5), new Vector3(20, 10, 0), 88, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(-20, 5, -5), new Vector3(20, 10, 0), 100, 2);

        Level.instance.generateEnemy(1, 1, 1, enemyFollowerPrefabName, new Vector3(20, 5, -5), new Vector3(20, 10, 0), 110, 2);

        Level.instance.generateEnemy(6, 2, 1, enemyInvadersPrefabName, new Vector3(3, 5, 0), new Vector3((float)0.7, 0, 0), 117, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(20, 10, -5), new Vector3(20, 10, 0), 123, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-2, 120, -5), new Vector3(5, Random.Range(2, 6), 0), 130, 2);

        Level.instance.generateEnemy(6, 2, 1, enemyInvadersPrefabName, new Vector3(-3, 7, 0), new Vector3((float)0.7, 0, 0), 145, 2);

        Level.instance.endWinLevel(Level.instance.levelDuration);

    }
}
