using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] float jumpDelta;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();
        rb = GetComponent<Rigidbody2D>();
    }
    private void SetUpBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+5;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-5;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+5;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-5;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpDelta);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, -jumpDelta);
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*moveSpeed;
        var newXPos =Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
