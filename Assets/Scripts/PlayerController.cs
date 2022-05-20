using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpScale = 1;
    public float liftingForce = 1000;

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
        if(Input.GetMouseButton(0))
        {
            if(rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0, liftingForce * Time.deltaTime * -rb.velocity.y));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle") && GameManager.instance.battery.isActive == false)
        {
            OnObstacleHit();
        }

        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.CoinCollected();
        }

        if(collision.CompareTag("Battery"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.BatteryCollected();
        }

        if(collision.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.MagnetCollected();
        }
    }

    private void OnObstacleHit()
    {
        if (!GameManager.instance.battery.isActive)
        {
            GameManager.instance.GameOver(); 
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position + (Vector3)playerCollider.offset,
            playerCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }
}
