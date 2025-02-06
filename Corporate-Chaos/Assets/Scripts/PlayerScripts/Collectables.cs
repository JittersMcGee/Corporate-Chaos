using UnityEngine;

public class Collectables : MonoBehaviour
{
    /// <summary>
    /// This class provides methods for the collectibles to exectute to add to the fields in the script.
    /// Shop script checks against the values to see if there are correct amounts of required material.
    /// </summary>
    #region Fields

    int blood = 0;
    int monies;
    int xp = 0;
    int level = 1;
    const float XPSCALE = 1.1f;
    float threshold = 100;

    #endregion

    #region Properties 

    public int Blood
    {
        get { return blood; }
    }
    public int Monies
    {
        get { return monies; }
    }

    
    public int Level
    {
        get { return level; }
    }

    public float XP
    {
        get { return xp; }
    }

    public float Threshold
    {
        get { return threshold; }
    }

    private void Update()
    {
        UpdateLevel();
    }

    #endregion

    #region Methods

    public void AddBlood(int value)
    {
        blood += value;
    }
    public void AddMonies(int value)
    {
        monies += value;
    }

    public void AddXP(int value)
    {
        xp += value;
    }

    public void UpdateThreshold()
    {
        threshold *= XPSCALE;
    }

    public void UpdateLevel()
    {
        if (xp >= threshold)
        {
            level++;
            UpdateThreshold();
        }
    }

    #endregion
}
