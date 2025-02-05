using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections.Specialized;
using System;

public class WeaponListInitializer 
{
    public WeaponTemplate[] weapons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
            weapons = Resources.LoadAll<WeaponTemplate>("Weapons");
            System.Array.Sort(weapons, CompareDropRates);
            System.Array.Reverse(weapons);
    }

    static int CompareDropRates(WeaponTemplate gun1, WeaponTemplate gun2)
    {
        return gun1.dropChance.CompareTo(gun2.dropChance);
    }
}
