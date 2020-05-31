using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wander : MonoBehaviour
{
    private Transform player;
    public GameObject enemy;
    private NavMeshAgent NavEnemy;
    private Transform target;
    public Transform[] checkpoints;
    private int num = 0;
    public bool go;
    // Start is called before the first frame update
    void Awake()
    {
        target = checkpoints[num];
        //Debug.Log(GameObject.Find("player").transform);
        NavEnemy = enemy.GetComponent<NavMeshAgent>();
        NavEnemy.SetDestination(GetDestination());

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = enemy.transform.position - target.position;
        direction.Normalize();
        // test = GameObject.Find("Player").transform;
        NavEnemy.SetDestination(target.position + (direction * 1));
        
    }
    public Vector3 GetDestination()
    {
        return target.position;
    }
    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject == checkpoints[num].gameObject && go == true)
        {
            Debug.Log("check");
            num++;
            target = checkpoints[num];
            go = false;
        }
    }
}
