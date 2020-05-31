using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public int threshhold = 0;
    public int[] goal;

    public int Q;
    public GameObject BF;
    public wander next;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (threshhold == goal[Q])
        {
            Q++;
            threshhold = 0;
            next.go = true;
        }
    }
}
