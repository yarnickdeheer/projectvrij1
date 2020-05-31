using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compas : MonoBehaviour
{
    public Transform player;
    public GameObject Compas;
    private Vector3 CompasRotate;
    public Transform[] signs;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
        var playerRotate = player.rotation.eulerAngles.y;

        //   Vector3 playerRotate = new Vector3(player.localRotation.x, player.localRotation.y, player.localRotation.z);
        
        //CompasRotate.z = player.rotation.y;
        Compas.transform.eulerAngles = new Vector3(Compas.transform.rotation.eulerAngles.x, Compas.transform.rotation.eulerAngles.y, playerRotate);
        for (int i = 0; i < signs.Length; i++)
        {
            signs[i].eulerAngles = new Vector3(0, 0, 0);
        }
 
    }
}
