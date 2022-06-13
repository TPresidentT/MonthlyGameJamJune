using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseHumans : MonoBehaviour
{
    float moveSpeed = 3f;
    Vector2 moveDirection;
    public Transform target;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = (target.position - transform.position).normalized;
        rigidbody.velocity = (new Vector2(moveDirection.x, moveDirection.y) * moveSpeed);
    }
}
