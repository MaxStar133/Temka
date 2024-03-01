using System.Collections;
using UnityEngine;
using TMPro;

public class TimeCont : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    [SerializeField] private TextMeshProUGUI TIMER;
    void Start()
    {
        StartCoroutine(TimeFlow());
    }
    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec++;
            TIMER.text = min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

}