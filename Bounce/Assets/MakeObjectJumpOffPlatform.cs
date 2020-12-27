using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectJumpOffPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity =
        new Vector2(0, 20.0f);
    }
}
