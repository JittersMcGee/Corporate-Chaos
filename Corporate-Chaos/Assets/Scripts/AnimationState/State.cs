using UnityEngine;

public abstract class State : MonoBehaviour
{
    /// <summary>
    /// a template that all states will derive from, each variable and method in this script will be accessible 
    /// throughout the child states
    /// </summary>
    protected Core core;

    protected Rigidbody2D rb2d => core.rb2d;
    protected Animator animator => core.animator;
    protected MovementScript input => core.input;

    protected GroundSensor groundSensor => core.groundSensor;

    //any class can check if state is complete but only derivatives can set bool
    public bool isComplete { get; protected set; }

    //only derivatives can change startTime
    protected float startTime;

    //this expression cannot be set, changes when called in state
    public float time => Time.time - startTime;

    //virtual expects derrivatives of this class to override these functions
    public virtual void Enter()
        { }
    public virtual void Do()
        { }
    public virtual void FixedDo()
        { }
    public virtual void Exit()
        { }

    public void SetCore(Core core)
    {
        this.core = core;
    }

    public void Initialize()
    {
        isComplete = false;
        startTime = Time.time;
    }
}
