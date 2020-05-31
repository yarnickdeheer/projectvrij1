using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public int scene;
    public bool psause;
    public FirstPersonController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.P))
        {
            psause = true;
            pause();
        }
    }
    public void pause()
    {
        if (psause == true)
        {
            Screen.lockCursor = false;
            Cursor.visible = true;
            controller.enabled = false;
        }
        controller.m_MouseLook.XSensitivity = 0;
        controller.m_MouseLook.YSensitivity = 0;
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    public void resume()
    {
        psause = false;
        Screen.lockCursor = true;
        Cursor.visible = false;
        controller.enabled = true;
        controller.m_MouseLook.XSensitivity = 2;
        controller.m_MouseLook.YSensitivity = 2;
        Time.timeScale = 1;
        menu.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
