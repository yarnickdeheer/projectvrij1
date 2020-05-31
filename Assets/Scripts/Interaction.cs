using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private enemyFollow[] seekers;
    private RockTrow throwScript;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void Awake()
    {

        throwScript = GameObject.Find("trow").GetComponent<RockTrow>();
        GameObject[] seeker = GameObject.FindGameObjectsWithTag("seekers");
        seekers = new enemyFollow[seeker.Length];
        for (int i = 0; i < seeker.Length; i++)
        {
            seekers[i] = seeker[i].GetComponent<enemyFollow>();
        }

      
        
     


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < seekers.Length; i++)
        {
            if (seekers[i].foundTarget == true)
            {
                
                    seekers[i].target = this.transform;
                    seekers[i].objective = true;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            throwScript.found = true;
       
        }
    }
}
 