using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseHumans : MonoBehaviour
{
    float moveSpeed = 3f;
    Vector2 moveDirection;
    public Transform target;
    Rigidbody2D rigidbody;
   // public Rigidbody2D prefabInfection;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        moveDirection = (target.position - transform.position).normalized;
        rigidbody.velocity = (new Vector2(moveDirection.x, moveDirection.y) * moveSpeed);
    }
  
    
  // void OnCollisionEnter2D(Collision2D collision)
  //  {
  //      if (collision.collider.tag == "Zombie")
  //      {
  //          Instantiate(prefabInfection, transform.position, transform.rotation);
  //          Destroy(gameObject);
  //      }

  //  }
}

