using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   Rigidbody2D rb;
   Animator animator;
   [SerializeField] GameObject direction;
   [SerializeField] float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
      DontDestroyOnLoad(gameObject);
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();

    }
Vector2 displacement;
    // Update is called once per frame
    void FixedUpdate()
    {
      displacement = new Vector2(
      Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")
      );
    displacement = Vector2.ClampMagnitude(displacement,1);

      rb.velocity = displacement * Time.deltaTime * speed;
      animator.SetFloat("speed",rb.velocity.magnitude);
      
      if (rb.velocity.magnitude >0.1f)
      {
      animator.SetFloat("Xspeed",rb.velocity.x);
      animator.SetFloat("Yspeed",rb.velocity.y);

      animator.SetBool("Walk", true);
      }
      else
      {
         animator.SetBool("Walk", false);
      }
      
    }
      
}
