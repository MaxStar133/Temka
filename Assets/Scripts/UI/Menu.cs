using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textRecord;
    private int record=0;
    private void Start()
    {
        record = PlayerPrefs.GetInt("Record", record);
        textRecord.text = "You record: " + record.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
