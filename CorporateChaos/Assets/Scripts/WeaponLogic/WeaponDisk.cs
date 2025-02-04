using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class WeaponDisk : MonoBehaviour
{
    #region Fields

    //collsion support
    [SerializeField]
    Collider2D playerCheck;
    [SerializeField]
    LayerMask playerMask;
    bool overlap;
    float interactInput;
    bool primaryWeaponEquipped;
    bool secondaryWeaponEquipped;

    //External support
    GameObject doug;
    PlayerWeaponStatus status;
    PrimaryWeapon primaryWeapon;
    SecondaryWeapon secondaryWeapon;

    //list of weapons and drop chance
    public List<WeaponTemplate> weapons = new List<WeaponTemplate>();
    float totalDropChance = 101f;
    float randomizer;

    // weapon stats import support
    public new string name;
    public float damage;
    public float weight;
    public float fireRate;
    public float dropChance;
    public bool meleeWeapon;

    #endregion

    #region Properties

    private void Awake()
    {
        PickGun();
    }

    private void Start()
    {
        doug = GameObject.FindGameObjectWithTag("Player");
        status = doug.GetComponent<PlayerWeaponStatus>();
        primaryWeapon = doug.GetComponent<PrimaryWeapon>();
        secondaryWeapon = doug.GetComponent<SecondaryWeapon>();
    }

    private void Update()
    {
        Comps();
        InteractCheck();
    }

    #endregion

    #region Methods

    /// <summary>
    /// using drop chance of scriptable object that is the weapon, run through list of weapons and compare the random number to
    /// drop chance, if drop chance is less than number then subtract the drop chance and move to next item till one is selected
    /// Range has to match total drop chance of items in list.
    /// </summary>
    void PickGun()
    {
        randomizer = Random.Range(0, totalDropChance);
        foreach (WeaponTemplate weapon in weapons)
        {
            if (weapon.dropChance >= randomizer)
            {
                this.name = weapon.name;
                this.damage = weapon.damage;
                this.weight = weapon.weight;
                this.fireRate = weapon.fireRate;
                this.dropChance = weapon.dropChance;
                this.meleeWeapon = weapon.meleeWeapon;
                break;
            }
            else
            {
                randomizer -= weapon.dropChance;
            }
        }
    }

    void InteractCheck()
    {
       if(overlap && interactInput > 0 && primaryWeaponEquipped)
        {
            primaryWeapon.SetStats(damage, fireRate, weight, meleeWeapon, name);
            Destroy(gameObject);
        }
       else if(overlap && interactInput > 0 && secondaryWeaponEquipped)
        {
            secondaryWeapon.SetStats(damage, fireRate, weight, meleeWeapon, name);
            Destroy(gameObject);
        }
    }

    //gets all required checks to allow interact, correct weapon change in correct slot.
    void Comps()
    {
        overlap = Physics2D.OverlapAreaAll(playerCheck.bounds.min, playerCheck.bounds.max, playerMask).Length > 0;
        interactInput = Input.GetAxis("Interact");
        primaryWeaponEquipped = status.PrimaryEquipped;
        secondaryWeaponEquipped = status.SecondaryEquipped;
    }

    #endregion
}
