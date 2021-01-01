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
    [SerializeField] GameObject bullet;
    [SerializeField] float speed = 5.0f;
    [SerializeField] GameObject gun;
    Rigidbody2D rb;
    Coroutine c;
    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();
        rb = GetComponent<Rigidbody2D>();
    }
    private void SetUpBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+6.5f;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x- 6.5f;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+ 6.5f;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y- 6.5f;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jumpDelta);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            c = StartCoroutine(Shoot());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(c);
            Debug.Log("Aaaa");
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*moveSpeed;
        var newXPos =Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
        rb.rotation = 30.0f;
        //transform.Rotate(0, 0, 10.0f);
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject lazar = Instantiate(bullet, gun.transform.position, gun.transform.rotation) as GameObject;
            lazar.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 10);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
