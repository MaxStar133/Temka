using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
 //   private Pistolet loseGun;
  //  private GameObject loseMenu;

    private void Start()
    {
       // loseGun = FindObjectOfType<Pistolet>().GetComponent<Pistolet>();
       // loseMenu = FindObjectOfType<GameObject>();
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
