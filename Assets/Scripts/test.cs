using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject platformB;
    public GameObject[] tests;
    private bool Switch = true;
    // Start is called before the first frame update
    void Start()
    {
         tests = GameObject.FindGameObjectsWithTag("yellow");
        foreach (GameObject element in tests)
        {

            element.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    if (Switch == false && Input.GetKeyDown(KeyCode.R))
    {
            Switch = true;
       
        platformB.SetActive(Switch);
            foreach (GameObject element in tests)
            {

                element.SetActive(!Switch);
            }
         
        }
    else if (Switch == true && Input.GetKeyDown(KeyCode.R))
    {
            Switch = false;

        platformB.SetActive(Switch);
            foreach (GameObject element in tests)
            {

                element.SetActive(!Switch);
            }
        }
    else
    {
        return;
    }

}
}
