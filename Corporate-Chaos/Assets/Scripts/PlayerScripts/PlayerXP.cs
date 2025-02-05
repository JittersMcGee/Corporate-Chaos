using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    #region Fields

    int xp = 0;
    int level = 1;
    const float XPSCALE = 1.1f;
    float threshold = 100;

    #endregion

    #region Properties

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
}
