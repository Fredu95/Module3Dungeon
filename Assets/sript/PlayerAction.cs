using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] Transform player;
    Animator animator;
    [SerializeField] float lifeTime;
    [SerializeField] float damage;
      [SerializeField] Vector3 playerLogation;
    [SerializeField] float hp=4;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.tag == "Key")
        {   //key give 4 more hp
          hp += 4;
           
           Destroy(other.gameObject);
        }
    
    else if (other.gameObject.tag == "Enemy")
       {    //Enemy hit
         hp -=1;
         
       Debug.Log(hp);
       transform.position = playerLogation;;
        if (hp ==0)
            {
            SceneManager.LoadScene("gameover");  
            animator.SetBool("hurt", true);
            //hp0 and player ded...
            Debug.Log("Life");
            Destroy(gameObject, 2f);
            }
       }
    }
    
}
