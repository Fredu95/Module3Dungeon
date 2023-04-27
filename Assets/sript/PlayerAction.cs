using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
   public static PlayerAction instance;
    enum PlayersState{
      Hurt,
      Idle
    }
    [SerializeField] Transform player;
    Animator animator;
    
    [SerializeField] Vector3 playerLogation;
    [SerializeField] PlayersState playerState = PlayersState.Idle;
    [SerializeField] float hurtTime = .3f;
    public  int hp=4;



    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
    }

   void StartIdling()
   {
    playerState = PlayersState.Idle;
   
   }
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.tag == "Key")
        {   //key give 4 more hp
          hp += 4;
           
           Destroy(other.gameObject);
        }
    
    else if (playerState != PlayersState.Hurt && other.gameObject.tag == "Enemy")
       {    //Enemy hit
         playerState = PlayersState.Hurt;
         hp -=1;
         UI.instance.UpdateLives(hp);
       Debug.Log(hp);
       transform.position = playerLogation;
       Invoke("StartIdling",hurtTime);
        
        
        if (hp ==0)
            { //hp0 and player ded...
            SceneManager.LoadScene("gameover");  
            animator.SetBool("hurt", true);
           
            
            }
       }
    }
    
}
