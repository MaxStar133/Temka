using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject pause;

    private Gun pauseGun;

    void Start()
    {
        pause.SetActive(false);
        pauseGun = FindObjectOfType<Gun>().GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          pauseGun.enabled = false;
            pause.SetActive(true);
            Time.timeScale = 0;

        }
    }


    public void PauseOff()
    {
       pauseGun.enabled = true;
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
