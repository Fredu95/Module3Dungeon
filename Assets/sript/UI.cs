using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    public static UI instance;
    [SerializeField] Image[] lifeImages; //elämiä näyttävät kuvat
    
    void Start()
    {
          if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        UpdateLives(PlayerAction.instance.hp);
    }

    // Update is called once per frame
     public void UpdateLives(int lives)
    {
        for (int i = 1; i < lifeImages.Length + 1; i++)
        {
            lifeImages[i - 1].enabled = lives >= i;
        }
    }
}
