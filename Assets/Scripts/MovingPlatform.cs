using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

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
        // change position of transform
        transform.position = Vector2.MoveTowards(
            rb.position,
            target,
            speed * Time.fixedDeltaTime
        );

        //Switch target
        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            if (target == (Vector2)pointA.position)
            {
                target = pointB.position;
            }
            else
            {
                target = pointA.position;
            }
        }
    }
    //Move Player with platform
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            collision2D.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            collision2D.transform.SetParent(null);
        }
    }
}
