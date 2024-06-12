using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float CharacterSpeed;
    Rigidbody2D rb;
    public BoxCollider2D BoxCollider;
    public LayerMask GroundLayer;
    private bool grounded;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(HorizontalInput * CharacterSpeed,rb.velocity.y);

        //karakter saða gidecekse saða döndür
        if (HorizontalInput> 0.01f)
        {
            transform.localScale = new Vector3(0.009f, 0.009f, 0.009f);
        }
        //Karakter sola gidecekse sola döndür
        else if (HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.009f, 0.009f, 0.009f);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            jump();
        }
    }
    public void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, CharacterSpeed);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider.bounds.center,BoxCollider.bounds.size,0,Vector2.down,0.1f,GroundLayer);
        return raycastHit.collider != null;
    }
}