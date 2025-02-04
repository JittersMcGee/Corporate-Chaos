using UnityEngine;

public class DashState : State
{
    public AnimationClip clip;
    //override overrides virtual function
    public override void Enter()
    {
        animator.Play(clip.name);
    }

    public override void Do()
    {
        if (!groundSensor.grounded)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }
}
