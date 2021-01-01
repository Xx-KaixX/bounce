using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public float RevSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);

    }
    void FixedUpdate()
    {
        MoveCharacter(movement);
    }
    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        
    }
    void RotateCharacter()
    {
        rb.MoveRotation(rb.rotation + RevSpeed * Time.fixedDeltaTime);
    }
}
