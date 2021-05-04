using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class Level1 : UnityEngine.MonoBehaviour
{
    private string enemyFollowerPrefabName = "FollowerEnemy";
    private string enemyShooterPrefabName = "ShooterEnemy";
    private string enemyInvadersPrefabName = "MediumEnemy";

    public string RockPrefabName = "Rock";
    public string RockPrefabName2 = "Stone";

    void Start()
    {
        Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-200, 200), Random.Range(1000, 1100), 0));

        Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-400, 400), Random.Range(1400, 1500), 0));

        Level.instance.generateRock(RockPrefabName, new Vector3(Random.Range(-300, 300), Random.Range(1600, 1700), 0));

        Level.instance.StartCoroutine(Level.instance.rockRandomApparition());

    }

    void Update()
    {
        //Phase 1
        Level.instance.generateEnemy(8, 1, 1, enemyInvadersPrefabName, new Vector3(-3, -120, 0), new Vector3((float)0.8, 0, 0), 7, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-3, -115, -5), new Vector3(5, 0, 0), 12, 2);

        Level.instance.generateEnemy(6, 1, 1, enemyInvadersPrefabName, new Vector3(0, -117, 0), new Vector3((float)0.8, Random.Range(0, 2), 0), 20, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-10, -70, -5), new Vector3(5, Random.Range(10, 6), 0), 25, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(10, -70, -5), new Vector3(5, Random.Range(10, 6), 0), 28, 2);

        Level.instance.generateEnemy(3, 2, 1, enemyFollowerPrefabName, new Vector3(-2, -90, -5), new Vector3(5, Random.Range(2, 6), 0), 32, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(-10, -110, -5), new Vector3(20, 0, 0), 36, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(10, -110, -5), new Vector3(20, 0, 0), 40, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(20, -120, -5), new Vector3(20, 10, 0), 46, 2);

        //Phase 2

        Level.instance.generateEnemy(4, 1, 1, enemyInvadersPrefabName, new Vector3(5, -118, 0), new Vector3((float)0.7, 0, 0), 55, 2);

        Level.instance.generateEnemy(2, 3, 1, enemyFollowerPrefabName, new Vector3(-20, -115, -5), new Vector3(40, 0, 0), 60, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(-2, -117, -5), new Vector3(5, 0, 0), 64, 2);

        Level.instance.generateEnemy(3, 3, 1, enemyFollowerPrefabName, new Vector3(2, -117, -5), new Vector3(5, 0, 0), 70, 2);
  
        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(-10, -125, -5), new Vector3(20, 0, 0), 76, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(20, -120, -5), new Vector3(20, 10, 0), 86, 2);

        Level.instance.generateEnemy(1, 3, 1, enemyFollowerPrefabName, new Vector3(-20, -120, -5), new Vector3(20, 10, 0), 100, 2);


        //Phase 3
        Level.instance.generateEnemy(1, 10, 1, enemyShooterPrefabName, new Vector3(0, -120, 0), new Vector3(5, 0, 0), 94, 2, new Vector3( (float)2.5, (float)2.5, (float)2.5));

        Level.instance.generateEnemy(2, 3, 1, enemyFollowerPrefabName, new Vector3(-10, -110, -5), new Vector3(20, 0, 0), 130, 2);

        Level.instance.endWinLevel(Level.instance.levelDuration);

    }
}
