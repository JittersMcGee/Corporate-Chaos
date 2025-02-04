using UnityEngine;

public class StateMachine
{
    public State state;

    /// <summary>
    /// creates function that checks if state has changed or if we called for a force reset, changes to new state
    /// </summary>
    /// <param name="newState"></param> state passed in from movment script
    /// <param name="forceReset"></param> special scenario to force a change
    public void Set(State newState, bool forceReset = false)
    {
        if (state != newState || forceReset)
        {
            state?.Exit();
            state = newState;
            state.Initialize();
            state.Enter();  
        }
    }

}
