using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject demon1Prefab;
    public int enemyCount = 0;

    public bool StartNewRound(int enemyAmmount)
    {
        while (enemyCount < enemyAmmount)
            StartCoroutine(GenerateEnemy());

        return true;
    }

    public IEnumerator GenerateEnemy()
    {
        enemyCount++;
        Instantiate(demon1Prefab, transform.position, Quaternion.identity);

        int randSecToWait = new System.Random().Next(1, 5);
        yield return new WaitForSeconds(randSecToWait);
    }


}

