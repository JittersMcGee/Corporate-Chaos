using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields

    const float HEALTH = 100;

    //modifiers
    float healthMod = 1;
    float speedMod = 1;
    float weightMod = 1;
    float dashSpeedMod = 1;

    bool airDash = false;
    bool groundSlam = false;
    bool dash = false;
    bool parry = false;

    [SerializeField]
    PlayerHealth healthScript;

    #endregion

    #region Properties
    
    public float Health
    { 
        get { return HEALTH; } 
    }
    public float HealthMod
    {
        get { return healthMod; }
    }
    public float SpeedMod
    {
        get { return speedMod; }
    }
    public float WeightMod
    {
        get { return weightMod; }
    }
    public float DashSpeedMod
    {
        get { return dashSpeedMod; }
    }
    public bool AirDash
    {
        get { return airDash; }
    }
    public bool GroundSlam
    {
        get { return groundSlam; }
    }
    public bool Dash
    {
        get { return dash; }
    }
    public bool Parry
    {
        get { return parry; }
    }

    #endregion

    #region Methods

    public void HealthModUpdate(float mod)
    {
        healthMod += mod;
        healthScript.UpdateMaxHealth();
    }

    public void SpeedModUpdate(float mod)
    {
        speedMod += mod;
    }

    public void WeightModUpdate(float mod)
    {
        weightMod += mod;
    }

    public void DashSpeedModUpdate(float mod)
    {
        dashSpeedMod += mod;
    }

    #endregion
}
