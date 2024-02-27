using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float timeToDamage;
    [SerializeField] private GameObject lozeMenu;
    [SerializeField] private AudioSource audioHit;
    [SerializeField] private TextMeshProUGUI textHealth;

    private Rigidbody2D rb;
    private EnemyHealth damage;
    private KilledEnemyDisplay enemyDisplay;
    private float time = 1;
    private bool playerDie = false;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        enemyDisplay = FindObjectOfType<KilledEnemyDisplay>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!playerDie)
        {
            if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
            {
                time += Time.deltaTime;
                if (time >= timeToDamage)
                {
                    TakeDamage();
                    GetComponent<AudioSource>().Play();
                    time = 0;
                }
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
        damage = FindObjectOfType<EnemyHealth>().GetComponent<EnemyHealth>();
        health= health- damage.damageEnemy;
        textHealth.text = health.ToString();



        if (health <= 0)
        {
            lozeMenu.SetActive(true);
            enemyDisplay.SetRecord();
            rb.bodyType = RigidbodyType2D.Static;
            playerDie = true;
            
        }
    }
}
