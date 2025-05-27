using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] public int health { set; get; } = 1000;

    private void Update()
    {
        if (health <= 0)
        {

        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log("health" + health);
    }

}
