using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Fields

    int price;
    int levelRequired;
    string type;
    [SerializeField]
    ShopLogic shopLogic;
    WeaponTemplate[] weapons;
    Collectables collectables;

    //interact support
    bool overlap;
    GameObject doug;
    PlayerWeaponStatus status;
    PrimaryWeapon primaryWeapon;
    SecondaryWeapon secondaryWeapon;
    float interactInput;
    bool primaryWeaponEquipped;
    bool secondaryWeaponEquipped;
    [SerializeField]
    BoxCollider2D playerCheck;
    [SerializeField]
    LayerMask playerMask;

    #endregion
    
    #region Properties

    void Start()
    {
        weapons = Resources.LoadAll<WeaponTemplate>("Weapons");
        System.Array.Sort(weapons, CompareDropRates);
        System.Array.Reverse(weapons);
        doug = GameObject.FindGameObjectWithTag("Player");
        status = doug.GetComponent<PlayerWeaponStatus>();
        primaryWeapon = doug.GetComponent<PrimaryWeapon>();
        secondaryWeapon = doug.GetComponent<SecondaryWeapon>();
        collectables = doug.GetComponent<Collectables>();
    }

    void Update()
    {
        Comps();
        ShopActivate();
    }

    #endregion

    #region Methods

    static int CompareDropRates(WeaponTemplate gun1, WeaponTemplate gun2)
    {
        return gun1.dropChance.CompareTo(gun2.dropChance);
    }

    void Comps()
    {
        overlap = Physics2D.OverlapAreaAll(playerCheck.bounds.min, playerCheck.bounds.max, playerMask).Length > 0;
        interactInput = Input.GetAxis("Interact");
        primaryWeaponEquipped = status.PrimaryEquipped;
        secondaryWeaponEquipped = status.SecondaryEquipped;
    }

    void ShopActivate()
    {
        if (overlap && interactInput != 0)
        {

        }
    }

    void BuyWithMonies()
    {
        if(shopLogic.LevelCheck(levelRequired, price, type))
        {
            collectables.AddMonies(-price);
        }
        else
        {
            //Ui suuport for did not meet requirements
        }
    }

    void BuyWithBlood()
    {
        if(shopLogic.LevelCheck(levelRequired, price, type))
        {
            collectables.AddBlood(-price);
        }
        else
        {
            //Ui suuport for did not meet requirements
        }
    }

    void BuyItem()
    {
        if (type == "Monies")
        {
            BuyWithMonies();
        }
        else if (type == "Blood")
        {
            BuyWithBlood();
        }
    }

    #endregion
}
