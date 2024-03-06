using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
[SerializeField] GameObject pause;
private Pistolet pauseGun;
    void Start()
    {
    pause.SetActive(false);
    pauseGun = FindObjectOfType<Pistolet>().GetComponent<Pistolet>();
    }

  
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
