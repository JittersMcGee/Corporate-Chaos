using UnityEngine;
using UnityEngine.Windows;

public class JumpState : State
{
    public AnimationClip clip;
    //override overrides virtual function
    public override void Enter()
    {
        animator.Play(clip.name);
    }

    public override void Do()
    {
        if (groundSensor.grounded)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }
}
