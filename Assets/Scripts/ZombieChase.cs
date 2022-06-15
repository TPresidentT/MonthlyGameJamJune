using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChase : MonoBehaviour

{

    private GameObject playerObject;

    private float distance;
    private float minimumDistance = 10f;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Human");
    }

    void Update()
    {
        distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= minimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, 3f * Time.deltaTime);
        }
    }
}