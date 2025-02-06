using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class ShopLogic : MonoBehaviour
{
    #region Fields

    int levelRequired;
    [SerializeField]
    Collectables collectables;
    int money => collectables.Monies;
    int blood => collectables.Blood;
    int level => collectables.Level;

    #endregion

    #region Properties


    #endregion

    #region Methods

    public bool MoniesCheck(int price)
    {
        if (money >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool BloodCheck(int price)
    {
        if (blood >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LevelCheck(int requirement, int price, string type)
    {
        if (level >= requirement && type == "Monies")
        {
            return MoniesCheck(price);
        }
        else if (level >= requirement && type == "Blood")
        {
            return BloodCheck(price);
        }
        else 
        {
            return false;
        }
    }

    #endregion
}
