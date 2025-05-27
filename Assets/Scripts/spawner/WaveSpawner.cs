using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public int count = 5;
        public float spawnRate = 1f;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private bool spawning = false;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        while (currentWaveIndex < waves.Length)
        {
            spawning = true;
            yield return StartCoroutine( SpawnWave(waves[currentWaveIndex]) );
            spawning = false;
            currentWaveIndex++;

            if (currentWaveIndex < waves.Length)
                yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject e = Instantiate(prefab, sp.position, sp.rotation);
        e.tag = "Enemy";

       
        var path = e.GetComponent<EnemyPathfinding>();
        if (path != null)
        {
            path.MoveTo( GameObject.FindGameObjectWithTag("Finish").transform.position );
        }
    }
}
