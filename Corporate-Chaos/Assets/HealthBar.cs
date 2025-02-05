using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetHealthBar(float health)
    {
        slider.value = health;
    }

    public void UpdateHealthBar(float damage)
    {
        slider.value -= damage;
    }
}
