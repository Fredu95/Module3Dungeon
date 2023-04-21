using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    [SerializeField] Transform ob3;
    [SerializeField] Vector3 ob3acceleration;
    [SerializeField] float distance;
    [SerializeField] Vector3 EnemyLogation;
     public Transform target;
     Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemy wakeup and follow player
       if (Vector3.Distance(target.position, ob3.position) < distance)
    {
        ob3.gameObject.GetComponent<Renderer>().material.color = Color.white;
       animator.SetBool("Eyes",true);
        ob3acceleration = (target.position -ob3.position).normalized * 5;
    ob3.position += Time.deltaTime * ob3acceleration;
    }
    else
    {   //enemy goes back to defoult position
        animator.SetBool("Eyes", false);
        ob3.gameObject.GetComponent<Renderer>().material.color = Color.black;
        transform.position = EnemyLogation;
    }
    }
}
