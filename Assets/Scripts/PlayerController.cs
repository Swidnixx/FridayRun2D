using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpScale = 1;
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    private bool doubleJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 jump = new Vector2(0f, jumpScale);
            if (IsGrounded())
            {
                rb.velocity = jump;
                doubleJumped = false;
            }
            else if(!doubleJumped)
            {
                rb.velocity = jump;
                doubleJumped = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            OnObstacleHit();
        }
    }

    private void OnObstacleHit()
    {
        GameManager.instance.GameOver();
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            playerCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }
}
