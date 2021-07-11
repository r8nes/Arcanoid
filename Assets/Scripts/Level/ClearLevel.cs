using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLevel : MonoBehaviour
{
    public void Clear()
    {
        BaseBlock[] allBlocks = FindObjectsOfType<BaseBlock>();
        if (allBlocks.Length > 0)
        {
            foreach (var item in allBlocks)
            {
                DestroyItem(item.gameObject);
            }
        }
        Bonus[] bonuses = FindObjectsOfType<Bonus>();
        if (bonuses.Length > 0)
        {
            foreach (var item in bonuses)
            {
                DestroyItem(item.gameObject);
            }
        }
    }
    private void DestroyItem(GameObject game)
    {
#if UNITY_EDITOR
        DestroyImmediate(game.gameObject);
#else
                Destroy(game.gameObject);
#endif
    }
}
