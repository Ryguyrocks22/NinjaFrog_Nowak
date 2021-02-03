using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;

    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    float horizontalValue;
    bool facingRight = true;
    [SerializeField] bool isGrounded = false;
    public float jumpPower = 500;
    bool jump = false;
    bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
            return;
        horizontalValue = Input.GetAxisRaw("Horizontal");

        //jumping
        if(Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
            jump = true;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        animator.SetFloat("yVelocity", rb.velocity.y);
        
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0)
            isGrounded = true;

        animator.SetBool("Jump", !isGrounded);
    }
    void Move(float dir, bool jumpFlag)
    {
        if(isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }
        #region Move & Run
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if(facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        else if(!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }
    public void Die()
    {
        isDead = true;
        SceneManager.LoadScene(2);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Prisoner")
        {
            SceneManager.LoadScene(3);
        }

    }

}
