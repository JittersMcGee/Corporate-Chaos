using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float damage;
    GameObject doug;

    Timer despawnTimer;

    void Start()
    {
        Comps();
    }

    private void Update()
    {
        if (despawnTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// checks for interaction with any enemy HB and runs the function in the enemy health script that adjusts properly based on damage
    /// variable in this script
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth health = coll.gameObject.GetComponent<EnemyHealth>();
            health.DamageEnemy(damage);
            Destroy(gameObject);
        }
    }

    void Comps()
    {
        doug = GameObject.FindGameObjectWithTag("Player");
        BulletDamage bulletDamage = doug.GetComponent<BulletDamage>();
        damage = bulletDamage.Damage;
        despawnTimer = gameObject.AddComponent<Timer>();
        despawnTimer.Duration = 2f;
        despawnTimer.Run();
    }
}
