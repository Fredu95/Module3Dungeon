using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBill : MonoBehaviour
{
    [SerializeField] GameObject Bum;
    [SerializeField] int count;
    [SerializeField] int limit;
    // Start is called before the first frame update
    void Start()
    {
    if(count < limit && Time.frameCount%20 ==0)
    {
        Debug.Log(Time.frameCount);
        Instantiate(Bum);
        
    }
    
    }
    
}
