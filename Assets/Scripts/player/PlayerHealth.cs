using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float timeToDamage;
    [SerializeField] private GameObject lozeMenu;
    [SerializeField] private AudioSource audio;
    private EnemyDamage damage;
    [SerializeField] private TextMeshProUGUI textHealth;

    private KilledEnemyDisplay enemyDisplay;
    private float time = 1;


    private void Start()
    {
        enemyDisplay = FindObjectOfType<KilledEnemyDisplay>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            time += Time.deltaTime;
            if (time >= timeToDamage)
            {
                TakeDamage();
                audio.Play();
                time = 0;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            time = 1;
        }
    }
    private void TakeDamage()
    {
        damage = FindObjectOfType<EnemyDamage>().GetComponent<EnemyDamage>();
        health= health- damage.damageEnemy;
        textHealth.text = health.ToString();



        if (health <= 0)
        {
            lozeMenu.SetActive(true);
            enemyDisplay.SetRecord();
            Destroy(gameObject);
        }
    }
}
