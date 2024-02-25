using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] private float speed;

	private Transform playerPosition;

	private void Start()
	{
	 playerPosition = FindObjectOfType<PlayerMove>().GetComponent<Transform>();
	}

	private void Update()
	{
		if (playerPosition != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
		}
	}
}
