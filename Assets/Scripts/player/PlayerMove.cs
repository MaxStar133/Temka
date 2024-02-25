using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private float speed;

   private Rigidbody2D rigidbody;
   private Vector2 moveInput;

   private void Start()
   {
     rigidbody = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
    moveInput.x = Input.GetAxisRaw("Horizontal");
    moveInput.y = Input.GetAxisRaw("Vertical");

   }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
