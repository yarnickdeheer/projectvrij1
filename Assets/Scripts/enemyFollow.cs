using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    private Transform player;
    public GameObject enemy;
    private NavMeshAgent NavEnemy;
    public GameObject bf;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool timer;
    public GameObject[] traps;
    public Next T;
    public bool test = true;
    public bool objective = true;
    public bool foundTarget = false;
    // Start is called before the first frame update
    void Awake()
    {
        target = this.transform;
        //Debug.Log(GameObject.Find("player").transform);
        NavEnemy = enemy.GetComponent<NavMeshAgent>();
        NavEnemy.SetDestination(GetDestination());

    }

    // Update is called once per frame
    void Update()
    {
        if (timer == true) 
        {
            if (test == true)
            {
                test = false;

                objective = false;
                T.threshhold++;
            }
            StartCoroutine("time");
            
        }
        Vector3 direction = enemy.transform.position - target.position;
        direction.Normalize();
        // test = GameObject.Find("Player").transform;
        if (foundTarget == true)
        {
            NavEnemy.SetDestination(target.position + (direction * 1));
        }
    }
    public Vector3 GetDestination()
    {
        return target.position;
    }
    private void OnTriggerEnter(Collider coll)
    {
        for (int i = 0; i < traps.Length; i++)
        {
            if (coll.gameObject == traps[i].gameObject && coll.gameObject == target.gameObject && objective == true)
            {
              
                timer = true;

            }
        }
    }
    private IEnumerator time()
    { 
         Transform tempTrans = target; 
        //
        yield return new WaitForSeconds(5f);
        if (target == tempTrans)
        {
            
             //target = bf.transform;
            
        }

        yield return new WaitForSeconds(5f);
        test = true;
        timer = false;
        

    }
}
