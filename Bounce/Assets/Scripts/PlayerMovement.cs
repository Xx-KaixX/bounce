using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public float RevSpeed = 100.0f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        SetUpBoundaries();
    }
    private void SetUpBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x +5f;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 5f;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 5f;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 5f;
    }
    // Update is called once per frame
    void Update()
    {
        //movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

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
