using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrow : MonoBehaviour
{
    public Transform Throw;
    public Transform parent;
    public Transform Mcamera;
    public GameObject player;
     public bool found = true;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        parent.localRotation = Mcamera.localRotation;
        if (Input.GetButtonUp("Fire1") && found == true)
        {
            found = false;
            var projectile = Instantiate(Throw, transform.position, parent.localRotation);
            
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 4000);
            Physics.IgnoreCollision(projectile.GetComponent<SphereCollider>(), player.GetComponent<CharacterController>());
           
        }

    }
}
