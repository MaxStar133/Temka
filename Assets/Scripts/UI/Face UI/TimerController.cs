using System.Collections;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
private int _sec = 0;
private int _min = 0;
[SerializeField] private TextMeshProUGUI timer;
[SerializeField] PlayerHealth player;
    void Start()
    {  
    StartCoroutine(TimeFlow());
    }
    IEnumerator TimeFlow()
    {
        while (!player.IsPlayerDie)
        {
            if (_sec == 59)
            {
            _min++;
            _sec = -1;
            }
        _sec++;
        timer.text = _min.ToString("D2") + ":" + _sec.ToString("D2");
        yield return new WaitForSeconds(1);
        }
    }

}