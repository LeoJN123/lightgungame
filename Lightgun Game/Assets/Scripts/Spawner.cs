using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemyContainer;
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    
    public Vector3 spawnerMovementV3;
    public float spawnerMovementSpeed;  
    public float spawnTime = 2f;
    [Tooltip("Number between 0 and 1")]
    public float difficultyPercentage = 0.95f;

    float waveEnemyNumber = 4;
    List<GameObject> enemiesAlive = new List<GameObject>();
    int wave;
    bool waveInProgress;

    public void WaveStart() {
        StartCoroutine(Spawning());
    }

    public void WaveEnd() {
        
        waveEnemyNumber *= 1.5f;
    }

    private void Start() {
        WaveStart();
    }   

    IEnumerator Spawning () {

        while (true) {
            InstantiateEnemy();
            yield return new WaitForSeconds(spawnTime);
            spawnTime *= difficultyPercentage;
            
        }
    }

    void InstantiateEnemy() {

        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        GameObject spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemy, spawn.transform.position, spawn.transform.rotation, enemyContainer.transform);
        enemiesAlive.Add(enemy);
        waveEnemyNumber--;
    }

    private void Update() {
        /* Rotating the spawner like a carousel */
        transform.Rotate(spawnerMovementV3 * spawnerMovementSpeed * Time.deltaTime);

        if (waveEnemyNumber <= 0) {
            StopCoroutine(Spawning());
        }

        if (waveEnemyNumber <= 0 && enemiesAlive.Count <= 0) {
            WaveEnd();
        }
    }
}
