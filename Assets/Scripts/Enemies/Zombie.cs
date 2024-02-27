using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public float health = 5f;
    [SerializeField] private AudioSource audioEnemy;
    [SerializeField] private float timeDie = 1.5f;
    public float damageEnemy = 1f;


    private KilledEnemyDisplay enemyDisplay;
	private EnemyMove move;
	private CircleCollider2D circleCollider;
	private Gun gun;
	private Animator anim;

	private float stunSpeed;
	private float speed;

	private void Start()
    {
		move = GetComponent<EnemyMove>();
		enemyDisplay = FindObjectOfType<KilledEnemyDisplay>().GetComponent<KilledEnemyDisplay>();
		circleCollider = GetComponent<CircleCollider2D>();
		anim = GetComponent<Animator>();
        gun = FindObjectOfType<Gun>().GetComponent<Gun>();

        stunSpeed = move.speed / 2;
		speed = move.speed;
    }
    private void ResetSpeed()
    {
        move.speed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
		  if(collision.gameObject.TryGetComponent(out Bullet bullet))
		  {
			TakeDamage();
			audioEnemy.Play();	
			Destroy(bullet.gameObject);
			Invoke ("ResetSpeed", gun.stun);
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
		if (FindObjectOfType<Gun>())
		{
			move.speed = stunSpeed;
			health = health - gun.damage;
			//health--;
		}
		else Debug.Log ("Dont FindObjectOfType<Gun>");

	if (health<=0)
	{
            anim.SetTrigger("zombieDie");
            audioEnemy.Play();
            move.enabled = false;
			circleCollider.enabled = false;
            Invoke("EnemyDisable", timeDie);
			
	}

   }



}
 