using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private AudioSource audio;
    [SerializeField] public int damage;

    private bool canShoot = true;

    private void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (Input.GetMouseButton(0) && canShoot) 
        {
            StartCoroutine(Shoot());
            audio.Play();
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false; 

        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(fireRate); 

        canShoot = true; 
    }
}