using Unity.VisualScripting;
using UnityEngine;

public abstract class Core : MonoBehaviour
{
    /// <summary>
    /// This class sets the core necessities for an animation state, scripts that change states should derive from this
    /// </summary>
    public Rigidbody2D rb2d;
    public Animator animator;
    public MovementScript input;
    public StateMachine stateMachine;
    public GroundSensor groundSensor;


    /// <summary>
    /// creates a list of all behavioural states located in gameObject and sets the core of them to this script
    /// </summary>
    public void SetUpInstances()
    {
        stateMachine = new StateMachine();

        State[] allChildStates = GetComponentsInChildren<State>();
        foreach (State state in allChildStates)
        {
            state.SetCore(this);
        }
    }
}
