using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    //class simplifies groundcheck to make it applicable to all entities that need it
    public  BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public bool grounded {  get; private set; }


    private void FixedUpdate()
    {
        CheckGround();
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

}
