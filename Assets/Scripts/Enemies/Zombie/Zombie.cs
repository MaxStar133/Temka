using UnityEngine;

public class Zombie : MonoBehaviour
{
public float health = 5f;
[SerializeField] private AudioSource audioEnemy;
[SerializeField] private float timeDie = 1.5f;
public GameObject ammoPrefab;
public GameObject HpPrefab;
private int randSpawnAmmo = 50;
private int randSpawnHP = 50;
private int incRandSpawnAmmo = 25;
private int incRandSpawnHP = 25;
public int minDamageEnemy = 1;
public int maxDamageEnemy = 2;
private int currentRandSpawnAmmo;
private int currentRandSpawnHP;
private ZombieMove move;
private CircleCollider2D circleCollider;
private Pistolet gun;
private Animator anim;
private float stunSpeed;
private float speed;
		
	private void Start()
    {
	move = GetComponent<ZombieMove>();
	circleCollider = GetComponent<CircleCollider2D>();
	anim = GetComponent<Animator>();
    gun = FindObjectOfType<Pistolet>().GetComponent<Pistolet>();

    stunSpeed = move.speed / 2;
	speed = move.speed;
	currentRandSpawnAmmo = randSpawnAmmo;
	currentRandSpawnHP = randSpawnHP;

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
    move.enabled = true;
    circleCollider.enabled = true;
    health = 4;
    }
	private void TakeDamage()
    {
		if (FindObjectOfType<Pistolet>())
		{
		move.speed = stunSpeed;
		health = health - Random.Range(gun.minDamage, gun.maxDamage+1);
		}
		else
		Debug.Log ("Dont FindObjectOfType<Gun>");

		if (health<=0)
		{
        anim.SetTrigger("zombieDie");
        audioEnemy.Play();
        move.enabled = false;
		circleCollider.enabled = false;
        Invoke("EnemyDisable", timeDie);
			if (Random.Range(0, 100 / currentRandSpawnAmmo) == 0)
			{
			DropAmmo();
			currentRandSpawnAmmo = randSpawnAmmo;
			}
			else
			currentRandSpawnAmmo += incRandSpawnAmmo;

			if (Random.Range(0, 100 / currentRandSpawnHP) == 0)
            {
			DropHP();
			currentRandSpawnHP = randSpawnHP;
			}
			else
			currentRandSpawnHP += incRandSpawnHP;
		}	
	}
	private void DropAmmo()
	{
	Instantiate(ammoPrefab, transform.position, Quaternion.identity); 
	}
	private void DropHP()
	{
	Instantiate(HpPrefab, transform.position, Quaternion.identity);
	}


}
 