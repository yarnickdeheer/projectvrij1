using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    private string[] scenePaths;
    public int scene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    public void start()
    {
        SceneManager.LoadScene(scene);
    }
    public void quit()
    {
        Application.Quit();
    }
}