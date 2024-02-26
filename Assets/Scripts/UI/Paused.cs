using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject pause;
   // public Gun gunScript;
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          //  gunScript.enabled = false;
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void PauseOff()
    {
       // gunScript.enabled = true;
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
