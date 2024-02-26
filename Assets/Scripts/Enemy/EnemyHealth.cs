using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField]  public int health;
    [SerializeField] private AudioSource audioEnemy;
    [SerializeField] private float timeDie = 1.5f;
    private KilledEnemyDisplay enemyDisplay;
	private EnemyMove move;
	private CircleCollider2D circleCollider;
	private Gun damage;

	private void Start()
    {
		move = GetComponent<EnemyMove>();
		enemyDisplay = FindObjectOfType<KilledEnemyDisplay>().GetComponent<KilledEnemyDisplay>();
		circleCollider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
		  if(collision.gameObject.TryGetComponent(out Bullet bullet))
		  {
			TakeDamage();
			audioEnemy.Play();	
			Destroy(bullet.gameObject);
		  }
   }
	public void EnemyDisable()
	{
        gameObject.SetActive(false);
        enemyDisplay.KilledEnemy();
        move.enabled = true;
        circleCollider.enabled = true;
        health = 4;
    }
	private void TakeDamage()
   {
		damage = FindObjectOfType<Gun>().GetComponent<Gun>();
		health = health - damage.damage;
		//health--;

	if (health<=0)
	{
            audioEnemy.Play();
            move.enabled = false;
			circleCollider.enabled = false;
            Invoke("EnemyDisable", timeDie);
	}

   }



}
 