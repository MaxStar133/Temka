using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
	[SerializeField]  public int health;
    [SerializeField] private AudioSource audioEnemy;
    [SerializeField] private float timeDie = 1.5f;
	private ZombieMove move;
	private CircleCollider2D circleCollider;
	private Pistolet damage;
	[SerializeField] public int damageEnemy;
	[SerializeField] public GameObject ammoPrefab;
	private void Start()
    {
		move = GetComponent<ZombieMove>();
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
        move.enabled = true;
        circleCollider.enabled = true;
        health = 4;
    }
	private void TakeDamage()
   {
		if (FindObjectOfType<Pistolet>())
		{
			damage = FindObjectOfType<Pistolet>().GetComponent<Pistolet>();
			health = health - damage.damage;
			//health--;
		}
		else Debug.Log ("Dont FindObjectOfType<Gun>");

		if (health<=0)
		{
            audioEnemy.Play();
            move.enabled = false;
			circleCollider.enabled = false;
            Invoke("EnemyDisable", timeDie);
			DropAmmo();
		}
		
	}
	private void DropAmmo()
	{
		Instantiate(ammoPrefab, transform.position, Quaternion.identity); // Создаем объект патрона
	}



}
 