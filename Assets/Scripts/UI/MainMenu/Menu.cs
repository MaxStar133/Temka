using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textRecord;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
