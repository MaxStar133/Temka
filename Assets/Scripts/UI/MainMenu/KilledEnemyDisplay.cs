using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KilledEnemyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int count=0;

    public void KilledEnemy()
    {
        count++;
        text.text = count.ToString();
    }
    public void SetRecord()
    {
        if(PlayerPrefs.GetInt("Record") < count)
        {
            PlayerPrefs.SetInt("Record", count);
        }
    }
}
