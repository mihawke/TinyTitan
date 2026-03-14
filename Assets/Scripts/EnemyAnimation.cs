using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Flip animation along x-axis
        spriteRenderer.flipX = true;
    }

    //Function to flip animation as required
    public void FlipAnimation(bool flip)
    {
        spriteRenderer.flipX = flip;
    }
}
