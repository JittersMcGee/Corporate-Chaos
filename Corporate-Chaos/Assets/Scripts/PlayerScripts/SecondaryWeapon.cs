using UnityEngine;

public class SecondaryWeapon : MonoBehaviour
{
    #region Fields

    string weaponName;
    float damage = 0;
    float fireRate = 0;
    float weight = 1;
    bool meleeWeapon = false;

    #endregion

    #region Properties

    //declare read only properties for other scripts to access
    public float Damage
    {
        get { return damage; }
    }

    public float FireRate
    {
        get { return fireRate; }
    }

    public float Weight
    {
        get { return weight; }
    }

    public bool MeleeWeapon
    {
        get { return meleeWeapon; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// this function changes the status of the stats in the secondary weapon slot, information is derived from WeaponDisk on pickup
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="fireRate"></param>
    /// <param name="weight"></param>
    /// <param name="meleeWeapon"></param>
    /// <param name="weaponName"></param>
    public void SetStats(float damage, float fireRate, float weight, bool meleeWeapon, string weaponName)
    {
        this.damage = damage;
        this.fireRate = fireRate;
        this.weight = weight;
        this.meleeWeapon = meleeWeapon;
        this.weaponName = weaponName;
    }

    #endregion
}
