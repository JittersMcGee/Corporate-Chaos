using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    OfficeHeavyEnemy HealthStat;
    public float health;
    const float minHealth = 0f;
    float maxHealth;

    /// <summary>
    /// retrieves health from stats script and executes based on the variables provided
    /// </summary>
    void Start()
    {
        HealthStat = gameObject.GetComponent<OfficeHeavyEnemy>();
        health = HealthStat.Health;
        maxHealth = HealthStat.Health;
    }

    private void Update()
    {
        Death();
    }

    public void DamageEnemy(float damage)
    {
        health = Mathf.Clamp(health - damage, minHealth, maxHealth);
    }

    void Death()
    {
        if (health == minHealth)
        {
            Destroy(gameObject);
        }
    }

    
}
