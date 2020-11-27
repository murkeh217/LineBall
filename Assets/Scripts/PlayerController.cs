using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpHeight;
    private float _resetPos = -4.05f;
    public Animator anim;
    private bool invincible = false;


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

    }

    public void Death()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector2(_resetPos, 0);

        if (!invincible)
        {
            invincible = true;
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Hurt", true);
            Debug.Log("Hurt");
            Invoke("ResetInvulnerability", 1);
            
        }
    }

    void ResetInvulnerability()
    {
        invincible = false;
        anim.SetBool("Hurt", false);
        GetComponent<Collider2D>().enabled = true;

    }

}