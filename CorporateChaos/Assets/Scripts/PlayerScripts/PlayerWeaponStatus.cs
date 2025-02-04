using UnityEngine;

public class PlayerWeaponStatus : MonoBehaviour
{
    #region Fields

    bool primaryEquipped;
    bool secondaryEquipped;

    float equipPrimary;
    float equipSecondary;

    #endregion

    #region Properties

    //create read only properties for other scripts to see which weapon is currently equipped
    public bool PrimaryEquipped
    {
        get { return primaryEquipped; }
    }

    public bool SecondaryEquipped
    {
        get { return secondaryEquipped; }
    }

    // Update is called once per frame
    private void Update()
    {
        WeaponChangeCheck();
        WeaponStatus();
    }

    #endregion

    #region Methods


    void WeaponChangeCheck()
    {
        equipPrimary = Input.GetAxis("PrimaryWeapon");
        equipSecondary = Input.GetAxis("SecondaryWeapon");
    }
    void WeaponStatus()
    {
        if (equipPrimary > 0)
        {
            primaryEquipped = true;
            secondaryEquipped = false;
            Debug.Log("Primary");
        }
        else if (equipSecondary > 0)
        {
            primaryEquipped = false;
            secondaryEquipped = true;
            Debug.Log("Secondary");
        }
        if (!primaryEquipped && !secondaryEquipped)
        {
            primaryEquipped = true;
        }
    }


    #endregion
}
