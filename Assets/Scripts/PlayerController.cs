using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpHeight;

    private float _resetPos = -4.05f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (transform.position.y > 18 || transform.position.y < -19)
        {
            Death();
        }

    }

    public void Death()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector2(_resetPos, 0);
    }
}