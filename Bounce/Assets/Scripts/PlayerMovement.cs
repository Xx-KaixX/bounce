using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 Movement;
    public float RevSpeed = 100.0f;

    // Jump Variables
    public float JumpForce;
    public float FallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")
        Movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        Jump();
    }

    void FixedUpdate()
    {
        MoveCharacter(Movement);
    }

    // MoveCharacter moves the character horizontally with consideration of speed
    void MoveCharacter(Vector2 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        rb.AddForce(direction * speed);
        //rb.AddTorque(direction * speed);

    }

    //RotateCharacter rotates the character at the speed of RevSpeed
    void RotateCharacter()
    {
        rb.MoveRotation(rb.rotation + RevSpeed * Time.fixedDeltaTime);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * JumpForce);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
