using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   Rigidbody2D rb;
   Animator animator;
   [SerializeField] float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
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

      rb.velocity = displacement * Time.deltaTime * speed;
      animator.SetFloat("speed",rb.velocity.magnitude);
      animator.SetFloat("Xspeed",rb.velocity.x);
      animator.SetFloat("Yspeed",rb.velocity.y);
      if (rb.velocity.magnitude >0){
      animator.SetBool("Walk", true);}
      else
      {
         animator.SetBool("Walk", false);
      }
      
      /* {
      animator.Play("Player_Walk");
      }
      else
      {
         animator.Play("Player_Idle");
      }*/
    }
}
