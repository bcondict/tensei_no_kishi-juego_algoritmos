using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGeneretorHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyGenerators;
    [SerializeField] private int[,] enemyRangeGenerator;

    public int totalEnemyAmmount = 0;

    private void Awake()
    {
        // enemyRangeGenerator = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        enemyRangeGenerator = new int[,] {
            {1, 5},
            {2, 7},
            {3, 8},
            {4, 9},
            {5, 10},
            {6, 11},
            {7, 12},
            {8, 13},
            {9, 14},
            {10, 15}
        };
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemies(enemyGenerators[0], 0));
        StartCoroutine(GenerateEnemies(enemyGenerators[1], 0));
        StartCoroutine(GenerateEnemies(enemyGenerators[2], 0));
        StartCoroutine(GenerateEnemies(enemyGenerators[3], 0));
        StartCoroutine(GenerateEnemies(enemyGenerators[4], 0));
    }

    private IEnumerator GenerateEnemies(GameObject enemyGeneretor, int wave)
    {
        EnemyGenerator enemyGeneratorScript = enemyGeneretor.GetComponent<EnemyGenerator>();

        int enemyAmmount = new System.Random().Next(enemyRangeGenerator[wave, 0], enemyRangeGenerator[wave, 1]);
        totalEnemyAmmount += enemyAmmount;

        bool done = enemyGeneratorScript.StartNewRound(enemyAmmount);

        yield return new WaitForSeconds(1f);
    }
}
