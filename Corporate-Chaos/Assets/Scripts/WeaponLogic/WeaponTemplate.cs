using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTemplate", menuName = "Scriptable Objects/WeaponTemplate")]
public class WeaponTemplate : ScriptableObject
{
    public new string name;
    public float damage;
    public float weight;
    public float fireRate;
    public int dropChance;
    public bool meleeWeapon;
    public int price;
    public int levelRequirement;

    public WeaponTemplate(string name, float damage, float weight, float fireRate, int dropChance, bool meleeWeapon, int price, int levelRequirement)
    {
        this.name = name;
        this.damage = damage;
        this.weight = weight;
        this.fireRate = fireRate;
        this.dropChance = dropChance;
        this.meleeWeapon = meleeWeapon;
        this.price = price;
        this.levelRequirement = levelRequirement;
    }
}
