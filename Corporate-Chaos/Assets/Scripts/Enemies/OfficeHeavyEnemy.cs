using UnityEngine;

public class OfficeHeavyEnemy : MonoBehaviour
{
    #region Fields

    const float HEALTH = 200f;
    const float SPEED = 1f;
    const float ROLLDAMAGE = 10f;
    const bool JUMP = false;

    #endregion

    #region Properties

    /// <summary>
    /// returns read only properties for other scripts to grab
    /// </summary>
    public float Health
    {
        get { return HEALTH; }
    }

    public float Speed
    {
        get { return SPEED; }
    }

    public float RollDamage
    {
        get { return ROLLDAMAGE; }
    }

    public bool Jump
    {
        get { return JUMP; }
    }
    #endregion
}
