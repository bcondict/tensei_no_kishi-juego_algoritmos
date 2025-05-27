using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


using UnityEngine.SceneManagement;

public class EnemyGeneratorHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyGenerators;
    [SerializeField] private int[,] enemyRangeGenerator;
    private int currentRound = 0;

    [SerializeField] private TMPro.TextMeshProUGUI roundText;

    public int totalEnemyAmmount = 0;

    private void Awake()
    {
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
        NextRound(0);
        roundText.text = "Round 1";
    }

    private void NextRound(int round)
    {
        if (round < 10)
        {
            StartCoroutine(GenerateEnemies(enemyGenerators[0], round));
            StartCoroutine(GenerateEnemies(enemyGenerators[1], round));
            StartCoroutine(GenerateEnemies(enemyGenerators[2], round));
            StartCoroutine(GenerateEnemies(enemyGenerators[3], round));
            StartCoroutine(GenerateEnemies(enemyGenerators[4], round));

            roundText.text = "Round " + (round + 1);

            return;
        }

        SceneManager.LoadScene("Menu");
    }

    private IEnumerator GenerateEnemies(GameObject enemyGeneretor, int wave)
    {
        EnemyGenerator enemyGeneratorScript = enemyGeneretor.GetComponent<EnemyGenerator>();

        int enemyAmmount = new System.Random().Next(enemyRangeGenerator[wave, 0], enemyRangeGenerator[wave, 1]);
        totalEnemyAmmount += enemyAmmount;

        enemyGeneratorScript.StartNewRound(enemyAmmount);

        yield return new WaitForSeconds(1f);
    }

    public void DieEnemy()
    {
        totalEnemyAmmount -= 1;
        CheckIfLast();
    }
    public void CheckIfLast()
    {
        if (totalEnemyAmmount <= 0)
        {
            NextRound(currentRound);
            currentRound += 1;
        }
    }
}
