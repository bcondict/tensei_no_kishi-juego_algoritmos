using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private GameObject castleGameObject;
    private Castle castleScript;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damage = 1;
    private State state;
    private EnemyPathfinding enemyPathfinding;

    private bool isTouchingCastle = false;

    private enum State
    {
        Roaming,
        Atacking,
        Moving
    }

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();

        castleGameObject = GameObject.Find("Castle");
        castleScript = castleGameObject.GetComponent<Castle>();

        state = State.Moving;
    }

    private void Start()
    {
        // StartCoroutine(RoamingRoutine());
        // StartCoroutine(MoveTowardCastle());
    }

    private void Update()
    {
        if (castleScript == null) return;

        if (isTouchingCastle)
        {
            StartCoroutine(AttackTheCastle());
        }
        if (!isTouchingCastle)
        {
            MoveTowardCastle();

        }
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamingPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamingPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void MoveTowardCastle()
    {
        Vector3 direction = (castleGameObject.transform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private IEnumerator AttackTheCastle()
    {
        Debug.Log("touching");
        while (state == State.Atacking)
        {
            castleScript.GetDamage(damage);
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Castle>())
        {
            Debug.Log("touching");
            isTouchingCastle = true;
            state = State.Atacking;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Castle>())
        {
            isTouchingCastle = false;
            state = State.Moving;
        }
    }
}
