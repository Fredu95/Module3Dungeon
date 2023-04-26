using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   Rigidbody2D rb;
   Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotPosition;
    [SerializeField] float shotForce;
    [SerializeField] float lifeTime;
    [SerializeField] float shotPeriod;
   [SerializeField] GameObject direction;
   [SerializeField] float speed = 200;
     float shotTime = 0f;
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
    displacement = Vector2.ClampMagnitude(displacement,1);

      rb.velocity = displacement * Time.deltaTime * speed;
      animator.SetFloat("speed",rb.velocity.magnitude);
      
      if (rb.velocity.magnitude >0.1f)
      {
      animator.SetFloat("Xspeed",rb.velocity.x);
      animator.SetFloat("Yspeed",rb.velocity.y);
      float SpeedX = animator.GetFloat("Xspeed");
      float SpeedY = animator.GetFloat("Yspeed");
      Debug.Log(SpeedX);
      animator.SetBool("Walk", true);
      }
      else
      {
         animator.SetBool("Walk", false);
      }
      if(Input.GetButtonDown("Jump"))
      {
        Debug.Log("shut");
        GameObject newbullet = Instantiate(bullet, shotPosition.position, transform.rotation);
            Rigidbody2D rb = newbullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * shotForce);
            Destroy(newbullet, lifeTime);
            shotTime=shotPeriod;

      }shotTime -= Time.deltaTime;
    }
      
}
