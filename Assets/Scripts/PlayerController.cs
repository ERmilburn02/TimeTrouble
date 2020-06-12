using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public GameObject endDemoUI;
    public GameObject player;
    public AudioSource jumpsfx;
    public AudioSource winsfx;
    private Animator animator;
    public GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player.Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
        CheckHealth();
        CheckCollectables();
    }

    void CheckHealth()
    {
        if (Player.Health == 0)
        {
            // Destroy(this.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.enabled = false;
            deathUI.SetActive(true);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x != 0)
        {
            animator.SetBool("IsMoving", true);
        } else
        {
            animator.SetBool("IsMoving", false);
        }

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if (Convert.ToBoolean(Input.GetAxis("Jump")) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (!jumpsfx.isPlaying) jumpsfx.Play();
        } else animator.SetBool("IsJumping", false);
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
            lastTimeGrounded = Time.time;
        }
        else
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }

    void CheckCollectables()
    {
        if (Player.Items == 5)
        {
            Debug.Log("ALL ITEMS COLLECTED!");
            Player.Items = 0;
            // TO DO: END LEVEL CODE
            endDemoUI.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
            winsfx.Play();

        }
    }

    public void restart()
    {
        Player.Health = 3;
        Player.Items = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
