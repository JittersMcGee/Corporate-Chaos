using UnityEngine;
using UnityEngine.UI;

public class HealthBarLogic : MonoBehaviour
{
    public Slider slider;

    public void SetHealthBar(float health)
    {
        slider.value = health;
    }

    public void Damage(float damage)
    {
        slider.value -= damage;
    }
}
