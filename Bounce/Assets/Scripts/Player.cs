using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();
    }
    private void SetUpBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+1;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-1;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+1;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-1;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*moveSpeed;
        var newXPos =Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);
        Debug.Log("Aaaa");
    }
}
