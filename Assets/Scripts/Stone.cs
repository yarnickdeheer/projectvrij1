using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Vector3 InpactPos;
    private Transform Stonepos;
    public GameObject stone;
    private RockTrow throwScript;
    private enemyFollow[] seekers;
    // Start is called before the first frame update
    void Start()
    {
    throwScript = GameObject.Find("trow").GetComponent<RockTrow>();
        GameObject[] seeker = GameObject.FindGameObjectsWithTag("seekers");
        seekers = new enemyFollow[seeker.Length];
        for (int i = 0; i < seeker.Length; i++)
        {
            seekers[i] = seeker[i].GetComponent<enemyFollow>();
        }

    }
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.gameObject.transform.position.y <= 3)
        {
            InpactPos = transform.position;
            GameObject test = Instantiate(stone, new Vector3 (InpactPos.x ,4.8f ,InpactPos.z), stone.transform.rotation);
            Stonepos = test.transform;
            for (int i = 0; i < seekers.Length; i++)
            {
                seekers[i].foundTarget = true;
            }
            Destroy(this.gameObject);
            

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)// 9 == ground layer
        {
            InpactPos = transform.position;
            GameObject test = Instantiate(stone, InpactPos, stone.transform.rotation);
            for (int i = 0; i < seekers.Length; i++)
            {
                seekers[i].foundTarget = true;
            }
            Destroy(this.gameObject);
          
        }
        if (collision.gameObject.layer == 4)// 9 == ground layer
        {
            InpactPos = transform.position;
            GameObject test = Instantiate(stone, InpactPos, stone.transform.rotation);
            for (int i = 0; i < seekers.Length; i++)
            {
                seekers[i].foundTarget = true;
            }
            Destroy(this.gameObject);

        }


    } 
    private void OnCollisionStay(Collision collision)
    {  
        if (collision.gameObject.layer == 9)// 9 == ground layer
        {
            InpactPos = transform.position;
            Instantiate(stone, InpactPos, stone.transform.rotation);
            Destroy(this.gameObject);
        }
    } 
   
}
