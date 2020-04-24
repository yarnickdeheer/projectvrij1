using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wander : MonoBehaviour
{
    private Transform player;
    public GameObject enemy;
    private NavMeshAgent NavEnemy;
    private Transform test;
    // Start is called before the first frame update
    void Awake()
    {
        test = GameObject.Find("Player").transform;
        //Debug.Log(GameObject.Find("player").transform);
        NavEnemy = enemy.GetComponent<NavMeshAgent>();
        NavEnemy.SetDestination(GetDestination());

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = enemy.transform.position - test.position;
        direction.Normalize();
        // test = GameObject.Find("Player").transform;
        NavEnemy.SetDestination(test.position + (direction * 1));
    }
    public Vector3 GetDestination()
    {
        return test.position;
    }
}
