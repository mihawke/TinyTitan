using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 1f;
    [SerializeField] private EnemyAnimation enemyAnimation;

    private Rigidbody2D rb;
    private Vector2 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = pointB.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            if (target == (Vector2)pointA.position)
            {
                target = pointB.position;
                enemyAnimation.FlipAnimation(true);
            }
            else
            {
                target = pointA.position;
                enemyAnimation.FlipAnimation(false);
            }
        }
    }
}
