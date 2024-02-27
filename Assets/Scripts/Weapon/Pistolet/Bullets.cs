using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private float timeToDestroy;

  private float _time;
  private void Update()
  {
		_time += Time.deltaTime;
		if (_time >= timeToDestroy)
		{
			Destroy(gameObject);
		}
		transform.Translate(Vector2.right * speed * Time.deltaTime);
  }
}
