using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private GameObject enemies;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        enemies = GameObject.Find("enemies");
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnoeckedBack(PlayerController.Instance.transform, 15f);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            GameObject flash = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            enemies.GetComponent<EnemyGeneratorHandler>().DieEnemy();
        }
    }
}
