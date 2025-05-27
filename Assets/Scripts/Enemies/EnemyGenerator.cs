using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject demon1Prefab;
    public int enemyCount = 0;

    public void StartNewRound(int enemyAmmount)
    {
        enemyCount = 0;
        while (enemyCount < enemyAmmount)
        {
            StartCoroutine(GenerateEnemy());
        }
    }

    public IEnumerator GenerateEnemy()
    {
        enemyCount++;
        Instantiate(demon1Prefab, transform.position, Quaternion.identity);

        int randSecToWait = new System.Random().Next(1, 5);
        yield return new WaitForSeconds(randSecToWait);
    }


}

