using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector2 prevVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        var direction = new Vector2(1, 1).normalized;
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int ChildCount()
    {
        return transform.childCount;
    }

    public void StartMove()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = prevVelocity;
    }

    public void StopMove()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        prevVelocity = rb.velocity;
        rb.velocity = new Vector2(0, 0);
    }
}
