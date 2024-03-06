using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private float speed;
    [SerializeField] private Animator anim;

   private Rigidbody2D rg;
   private Vector2 moveInput;

   private void Start()
   {
        rg = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        CheckAnimation();


   }
    private void FixedUpdate()
    {
        if (rg.bodyType != RigidbodyType2D.Static)
        rg.MovePosition(rg.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void CheckAnimation()
    {
        if (moveInput.magnitude > 0)
        {
            anim.SetInteger("state", 1);
        }
        else
        {
            anim.SetInteger("state", 0);
        }
    }
}
