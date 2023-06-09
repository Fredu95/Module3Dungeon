using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DungeonMaster;

public class Lock : MonoBehaviour
{
    public KeyTypeEnum keyType;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && DungeonMaster.instance.PlayerHasKey(keyType))
        {
            Destroy(gameObject);
            DungeonMaster.instance.AddKeys(keyType, -1);
        }
    }

}