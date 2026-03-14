using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private AnimationState currentState;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public enum AnimationState
    {
        Player_Idle,
        Player_Run,
        Player_Jump,
        Player_Fall
    }

    public void CurrentAnimation(AnimationState newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        animator.Play(newState.ToString());
    }

    public IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
