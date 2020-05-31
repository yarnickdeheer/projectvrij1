using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Sound : MonoBehaviour
{
    public GameObject player;
    public Transform[] traps;
    public enemyFollow[] seekers;
    public FirstPersonController controller;
    public AudioClip wet;
    public AudioClip[] dry;

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
        if (coll.gameObject.tag == "interact")
        {
            Debug.Log("interact");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               
            }
        }
      
        // Debug.Log(coll.gameObject.name);
        for (int i = 0; i < traps.Length;i++)
        {
            if (coll.gameObject.transform == traps[i])
            {
               // Debug.Log("ja" + traps[i].gameObject.name);

                for (int a = 0; a< seekers.Length;a++)
                {
                    seekers[a].target = coll.gameObject.transform;
                    seekers[a].objective = true;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            controller.m_WalkSpeed = 2;
            controller.m_RunSpeed = 4;
            controller.m_FootstepSounds[0] = wet;
            controller.m_FootstepSounds[1] = wet;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            controller.m_WalkSpeed = 4;
            controller.m_RunSpeed = 8;
            controller.m_FootstepSounds[0] = dry[0];
            controller.m_FootstepSounds[1] = dry[1];
        }
    }

}
