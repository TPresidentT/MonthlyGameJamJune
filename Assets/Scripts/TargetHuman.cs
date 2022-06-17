using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHuman : MonoBehaviour
{
    float zombieSpeed = 2f;
    private GameObject[] enemies;
    private Transform targetedEnemyPosition;
    private GameObject targetedEnemy;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FindClosestHuman()
    {
        //Find closest human
        enemies = GameObject.FindGameObjectsWithTag("Human");
        Vector2 shortestDistanceToHuman = new Vector2(1000, 1000);
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector2 distanceToHuman = transform.position - enemies[i].transform.position;
            if (distanceToHuman.magnitude < shortestDistanceToHuman.magnitude)
            {
                shortestDistanceToHuman = transform.position - enemies[i].transform.position;
                targetedEnemy = enemies[i];
                targetedEnemyPosition = targetedEnemy.transform;
            }
        }

        //Find random human
        //enemies = GameObject.FindGameObjectsWithTag("Human");
        //targetedEnemy = enemies[Random.Range(0, enemies.Length)];
        //targetedEnemyPosition = targetedEnemy.transform;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Human").Length > 0)
        {
            FindClosestHuman();

            float step = zombieSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetedEnemyPosition.position, step);

            Vector2 direction = (targetedEnemyPosition.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}