using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
   public enum KeyTypeEnum
   {
    Blue,
    Yellow,
    Green
   }
   public int blueKey = 0;
   public int greenKey = 0;
   public int yellowKey = 0;
   public string spawnLocationName;
   public static DungeonMaster instance;

   public bool PlayerHasKey(KeyTypeEnum keyType)
   {
    if (keyType == KeyTypeEnum.Blue)
    {
        return blueKey > 0;
    }
    else if (keyType == KeyTypeEnum.Green)
    {
        return greenKey > 0;
    }
    else if (keyType == KeyTypeEnum.Yellow)
    {
        return yellowKey > 0;
    }
    return false;
   }
   public void AddKeys(KeyTypeEnum keyType, int amaout)
   {
        if(keyType == KeyTypeEnum.Blue)
        {
            blueKey += amaout;
        }
        else if(keyType == KeyTypeEnum.Green)
        {
            greenKey += amaout;
        }
        else if(keyType == KeyTypeEnum.Yellow)
        {
            yellowKey += amaout;
        }
        
   }
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
             instance = this;
             DontDestroyOnLoad(gameObject);
        }
    }
}
