using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    /// <summary>
    /// This class creates a bullet prefab when prompted and sets the damage accordingly
    /// </summary>
    #region Fields

    //gun stats
    float damage;
    float fireRate;
    float shoot;
    
    //bullet stats
    [SerializeField]
    GameObject bulletprefab;
    float direction;
    const float BULLETMAGNITUDE = 50f;

    //comps
    PrimaryWeapon primaryWeapon;
    SecondaryWeapon secondaryWeapon;
    PlayerWeaponStatus weaponStatus;
    GroundSensor groundSensor;
    Timer fireRateTimer;

    #endregion

    #region Properties

    //read only stat for bullet to grab once made
    public float Damage
    {
        get { return damage; }
    }
    private void Start()
    {
        CompStart();
    }

    private void Update()
    {
        DamageSet();
        InputManager();
        CreateBullet();
    }

    #endregion

    #region Methods

    private void DamageSet()
    {

        if (weaponStatus.PrimaryEquipped && !primaryWeapon.MeleeWeapon)
        {
            damage = primaryWeapon.Damage;
            fireRate = primaryWeapon.FireRate;
        }
        else if (weaponStatus.SecondaryEquipped && !secondaryWeapon.MeleeWeapon)
        {
            damage = secondaryWeapon.Damage;
            fireRate = secondaryWeapon.FireRate;
        }
    }

    void InputManager()
    {
        shoot = Input.GetAxis("Attack");
    }

    private void CreateBullet()
    {
        if (groundSensor.grounded)
        {
            if (shoot > 0 && fireRateTimer.Finished && damage != 0)
            {
                GameObject bullet = Instantiate<GameObject>(bulletprefab);
                Rigidbody2D bulletrb2d = bullet.GetComponent<Rigidbody2D>();
                Vector3 location = gameObject.transform.GetChild(0).transform.position;
                bullet.transform.position = location;
                float parentDirection = gameObject.transform.rotation.y;
                direction = Mathf.Sign(parentDirection);
                bulletrb2d.linearVelocity = new Vector2(BULLETMAGNITUDE * direction, -0.01f);

                fireRateTimer.Duration = fireRate;
                fireRateTimer.Run();
            }
        }
    }

    void CompStart()
    {
        primaryWeapon = GetComponent<PrimaryWeapon>();
        secondaryWeapon = GetComponent<SecondaryWeapon>();
        weaponStatus = GetComponent<PlayerWeaponStatus>();
        groundSensor = GetComponent<GroundSensor>();
        fireRateTimer = gameObject.AddComponent<Timer>();
        fireRateTimer.Duration = 0.5f;
        fireRateTimer.Run();
    }

    #endregion
}
