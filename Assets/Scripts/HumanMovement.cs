using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    float moveSpeed = 2f;
    Vector2 moveDirection;
    float directionSetTime = 0f;
    float timerLength;
    Rigidbody2D rigidbody;
    public Rigidbody2D prefabInfection;
    int humansToInfect = 1;
<<<<<<< HEAD
=======
    bool wasClicked = false;
>>>>>>> main

    public void HumanInfection()
    {
        Instantiate(prefabInfection, transform.position, transform.rotation, GameObject.Find("Zombies").transform);
        transform.gameObject.tag = "Zombie";

        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timerLength = Random.Range(2f, 3f);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Zombie").Length > 0)
        {
            //Count down timer
            directionSetTime -= Time.deltaTime;

            //Human movement
            if (directionSetTime <= 0)
            {
                moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                directionSetTime = timerLength;
            }

            rigidbody.velocity = (new Vector2(moveDirection.x, moveDirection.y) * moveSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Collider") || (col.gameObject.tag == "Human"))
        {
            //Move in opposite direction
        }
        else
        {
            HumanInfection();
        }
    }

    void OnMouseDown()
    {
     //   if (!wasClicked == true)
        if (humansToInfect >= 0)
        {
            HumanInfection();
       //     wasClicked = false;

           // wasClicked = true;
             humansToInfect -= 1;
        }
    }
}
