using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHuman : MonoBehaviour
{
    public float zombieSpeed = 4f;
    private GameObject[] enemies;
    private Transform targetedEnemyPosition;
    private GameObject targetedEnemy;

    void Awake()
    {
        FindHuman();
    }

    void FindHuman()
    {
        enemies = GameObject.FindGameObjectsWithTag("Human");
        targetedEnemy = enemies[Random.Range(0, enemies.Length)];
        targetedEnemyPosition = targetedEnemy.transform;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Human")
        {
            FindHuman();
        }
    }

    void Update()
    {
        float step = zombieSpeed * Time.deltaTime;
     //   transform.position = Vector2.MoveTowards(transform.position, targetedEnemy.position, step);
        transform.position = Vector2.MoveTowards(transform.position, targetedEnemyPosition.position, step);

        if (targetedEnemy.tag != "Human")
        {
            FindHuman();
            Debug.Log("Hit");
        }
    }
}