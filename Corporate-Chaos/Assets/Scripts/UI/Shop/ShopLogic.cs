using UnityEngine;

public class ShopLogic : MonoBehaviour
{
    #region Fields

    int price;
    int levelRequired;
    [SerializeField]
    CollectablesStatus collectables;
    int monies => collectables.Monies;
    int blood => collectables.Blood;
    int level => collectables.Level;

    #endregion

    #region Properties


    #endregion
}
