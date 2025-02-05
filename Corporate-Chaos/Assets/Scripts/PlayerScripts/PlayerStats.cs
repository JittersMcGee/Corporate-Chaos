using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float health;
    float speed;
    float weight;
    float regen;
    float dashSpeed;

    public HealthBarLogic healthBar;

    bool airDash = false;
    bool groundSlam = false;
    bool dash = false;
    bool parry = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100; //+ modifiers
        healthBar.SetHealthBar(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            health -= 10;
            healthBar.Damage(10);
        }
    }
}
