using Unity.VisualScripting;
using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    Timer delay;

    private void Awake()
    {
        delay = gameObject.AddComponent<Timer>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        delay.Duration = 5;
        delay.Run();
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    private void Update()
    {
        if(delay.Finished)
        {
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            animator.Play("Intro");
        }
    }
}
