using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CastleHealth : MonoBehaviour
{
    [Header("Vida del castillo")]
    public int maxHealth = 10;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
