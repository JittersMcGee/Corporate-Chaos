using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Fields

    float currentHealth;
    float maxHealth;
    const float MINHEALTH = 0;
    PlayerStats stats;
    [SerializeField]
    HealthBarLogic healthBar;

    #endregion

    #region Properties

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        maxHealth = stats.Health * stats.HealthMod;
        currentHealth = maxHealth;
        healthBar.SetHealthBar(maxHealth);
    }

    private void Update()
    {
        Death();
    }

    #endregion

    #region Methods
    public void UpdateMaxHealth()
    {
        maxHealth = stats.Health * stats.HealthMod;
        currentHealth *= Mathf.Clamp(currentHealth * stats.HealthMod, MINHEALTH, maxHealth);
    }

    public void Damage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, MINHEALTH, maxHealth);
    }

    public void Death()
    {
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
