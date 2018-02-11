using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Rigidbody2D rb;
    public float velocity;
    public KeyCode jumpButton;
    private bool facingRight = true;
    [Range(1, 10)]
    public float jumpVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y);
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-velocity * Time.deltaTime, rb.velocity.y);
            if (facingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetKeyDown(jumpButton))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(jumpButton))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
