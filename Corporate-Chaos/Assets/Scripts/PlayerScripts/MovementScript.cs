using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : Core
{
    #region Fields

    //Serializers

    //Animator State Support
    [SerializeField]
    State runState;
    [SerializeField]
    State jumpState;
    [SerializeField]
    State dashState;
    [SerializeField]
    State idleState;

    //SubScript support
    [SerializeField]
    PlayerStats stats;

    // declares movement variables
    float MoveSpeed => 17f * stats.SpeedMod;
    public float JumpSpeed = 45f;
    float DashSpeed => 2f * stats.DashSpeedMod;
    const float GRAVITYSCALE = 1.015f;
    public float maxGrav;
    public float minGrav;
    public float horizontalMovement { get; private set; }
    public float jumpMovement { get; private set; }
    public float dashMovement { get; private set; }
    public float attack { get; private set; }

    bool facingRight = true;
    bool isDashing = false;


    

    //Timers
    Timer dashTimer;
    Timer dashDuration;
    const float DASHCOOLDOWN = 0.6f;



    #endregion

    #region Properties

    void Start()
    {
        StateStarts();
        TimerSetup();
    }


    void Update()
    {
        // creates support for and executes changing the movement variable
        GetInput();
        HorizontalCheck();
        JumpCheck();
        DashCheck();
        SelectState();
        stateMachine.state.Do();
    }

    #endregion


    #region Methods

    void GetInput()
    {
        //initializes input every frame
        horizontalMovement = Input.GetAxis("Horizontal");
        jumpMovement = Input.GetAxis("Jump");
        dashMovement = Input.GetAxis("Dash");
        attack = Input.GetAxis("Attack");
    }
    void HorizontalCheck()
    {
        if (horizontalMovement != 0 && !isDashing)
        {
            //sets speed of horizontal movement
            float direction = Mathf.Sign(horizontalMovement);
            rb2d.linearVelocity = new Vector2(direction * MoveSpeed, rb2d.linearVelocityY);
            // changes the direction of player
            if (horizontalMovement > 0 && !facingRight)
            {
                FlipPlayer();
            }
            else if (horizontalMovement < 0 && facingRight)
            {
                FlipPlayer();
            }
        }
        else if (horizontalMovement == 0)
        {
            rb2d.linearVelocity = new Vector2(0, rb2d.linearVelocityY);
        }
    }

    void JumpCheck()
    {
        
        if (jumpMovement != 0 && groundSensor.grounded)
        {
            rb2d.linearVelocity = new Vector2 (rb2d.linearVelocityX, JumpSpeed);
        }
        if(rb2d.linearVelocityY < 1)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, Mathf.Clamp(rb2d.linearVelocityY * GRAVITYSCALE, minGrav, maxGrav));
        }
    }

    void DashCheck()
    {
        if (dashMovement != 0 && groundSensor.grounded && dashTimer.Finished && !isDashing)
        {
            isDashing = true;
            Vector2 direction = new Vector2(rb2d.linearVelocityX, 0);
            rb2d.AddForce(direction * DashSpeed, ForceMode2D.Impulse);
            dashDuration.Run();
        }
        if (dashDuration.Finished)
        {
            dashDuration.Stop();
            dashTimer.Duration = DASHCOOLDOWN;
            dashTimer.Run();
            isDashing = false;
        }
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// uses logic to select which state needs to be played based on player input
    /// </summary>
    void SelectState()
    {
        if (groundSensor.grounded)
        {
            if (horizontalMovement != 0)
            {
                if (isDashing)
                {
                    stateMachine.Set(dashState);
                }
                else
                {
                    stateMachine.Set(runState);
                }
            }
            else
            {
                stateMachine.Set(idleState);
            }
        }
        else
        {
            stateMachine.Set(jumpState);
        }

        
    }

    void StateStarts()
    {
        SetUpInstances();
        stateMachine.Set(idleState);
    }

    void TimerSetup()
    {
        dashTimer = gameObject.AddComponent<Timer>();
        dashTimer.Duration = 0.5f;
        dashTimer.Run();

        dashDuration = gameObject.AddComponent<Timer>();
        dashDuration.Duration = 0.3f;
    }

    #endregion
}
