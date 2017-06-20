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
    public float wavePause = 5f;
    [Tooltip("Number between 0 and 1")]
    public float difficultyPercentage = 0.95f;

    public float startEnemyNumber = 4;
    public float waveEnemyNumber;
    List<GameObject> enemiesAlive = new List<GameObject>();
    int wave;
    bool waveInProgress;

    public void WaveStart() {
        StartCoroutine(Spawning());
        waveEnemyNumber = startEnemyNumber;
    }

    public void WaveEnd() {
        StartCoroutine(WaveLimbo());
        StopCoroutine(Spawning());
        startEnemyNumber *= 1.5f;
    }

    private void Start() {
        StartCoroutine(WaveLimbo());
    }
    IEnumerator WaveLimbo() {
        yield return new WaitForSeconds(wavePause);
        WaveStart();
        yield return null;
    }

    IEnumerator Spawning() {

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
