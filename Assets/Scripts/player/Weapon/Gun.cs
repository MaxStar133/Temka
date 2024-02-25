using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  [SerializeField] private GameObject bullet;
  [SerializeField] private Transform spawnPoint;

  private void Update()
  {
		Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
		}
  }
}
