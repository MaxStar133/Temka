using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistolet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private AudioSource audioGun;
    public float damage=1f;
    public float stun = 0.2f;
    public int maxAmmo = 7; // ������������ ���������� ��������
    public int currentAmmo; // ������� ���������� ��������

    private bool canShoot = true;
    private void Start()
    {
        currentAmmo = maxAmmo; // �������������� ���������� �������� ��� ������
    }
    private void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (Input.GetMouseButton(0) && canShoot) 
        { 
            currentAmmo--;
            StartCoroutine(Shoot());
            audioGun.Play();
            if (currentAmmo <= 0)
            {
                canShoot = false;
            }
        }
        if (currentAmmo <= 0)
        {
            canShoot = false;
        }

    }
    public void AddAmmo(int amount)
    {
        Debug.Log(3);
        currentAmmo += amount; // ����������� ������� ���������� ��������
        if (currentAmmo > 0)
        {
            canShoot = true;
        }
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo); // ������������ ���������� �������� ������������ ���������
       
    }

    private IEnumerator Shoot()
    {
        canShoot = false; 

        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(fireRate); 

        canShoot = true; 
    }
}