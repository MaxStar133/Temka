using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float timeToDamage;
    [SerializeField] private GameObject lozeMenu;
    [SerializeField] private AudioSource audioHit;
    private Zombie damage;
    [SerializeField] private TextMeshProUGUI textHealth;

    private float time = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Zombie enemy))
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Zombie enemy))
        {
            time = 1;
        }
    }
    private void TakeDamage()
    {
        damage = FindObjectOfType<Zombie>().GetComponent<Zombie>();
        health= health- damage.damageEnemy;
        textHealth.text = health.ToString();



        if (health <= 0)
        {
            lozeMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}
