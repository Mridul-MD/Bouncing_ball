using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerscript : MonoBehaviour
{
    // player movements
    [SerializeField] float speed = 100f;
    [SerializeField] float jumppower;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    public HealthBar healthbar;
    private Rigidbody2D rb;
    Vector3 spawnpoint;
    public int playermaxhealth = 100;
    public int playerhealth;
    bool isfacingright = true;
    float horizontal;
    bool doublejump;
    bool doublejumpSkill;

   

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        spawnpoint = transform.position;
        playerhealth = playermaxhealth;
        healthbar.SetMaxHealth(playermaxhealth);
    }
    void Update()
    {

        if(isfacingright && horizontal < 0f)
        {
            Flip();
        }
        else if (!isfacingright && horizontal > 0f)
        { 
            Flip();
        }

        if (playerhealth < 0)
        {
            destroyobject();
        }


    }

    private void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }
   
    private bool IsGrounded()
    {
       
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.02f,0.01f),CapsuleDirection2D.Horizontal,0, groundLayer);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
            doublejump = true;
        }
        else if (context.performed && doublejump && doublejumpSkill)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
            doublejump = false;
        }

        //if(context.canceled && rb.velocity.y > 0)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        //}
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("doublejumpp"))
        {
            doublejumpSkill= true;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("checkpoint"))
        {
            spawnpoint = collision.transform.position;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("playerkiller"))
        {
            TakeDamagePlayer(40);
        }
        
    }

    public void TakeDamagePlayer(int damage)
    {
    
        playerhealth -= damage;
        healthbar.SetHealth(playerhealth);
    }

    void destroyobject()
    {
        
        transform.position = spawnpoint;
        playerhealth = playermaxhealth;
        healthbar.SetMaxHealth(playermaxhealth);
    }



    private void Flip()   
    {
        isfacingright =!isfacingright;
        transform.Rotate(0f, 180f, 0f);
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        
    }


}
