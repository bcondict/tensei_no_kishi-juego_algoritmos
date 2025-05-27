using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1000;
    private Slider healthSlider;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }
    private void Update()
    {
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        // Debug.Log("health" + health);
        UpdateHealthSlider();
        CheckIfCastleIsDestroyed();
    }

    private void CheckIfCastleIsDestroyed()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameOver");

        }
    }
    private void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

}
