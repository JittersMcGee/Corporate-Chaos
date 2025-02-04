using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTemplate", menuName = "Scriptable Objects/WeaponTemplate")]
public class WeaponTemplate : ScriptableObject
{
    public new string name;
    public float damage;
    public float weight;
    public float fireRate;
    public float dropChance;
    public bool meleeWeapon;

    public WeaponTemplate(string name, float damage, float weight, float fireRate, float dropChance, bool meleeWeapon)
    {
        this.name = name;
        this.damage = damage;
        this.weight = weight;
        this.fireRate = fireRate;
        this.dropChance = dropChance;
        this.meleeWeapon = meleeWeapon;
    }
}
