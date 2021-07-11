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
        BallMove[] balls = FindObjectsOfType<BallMove>();
        if (balls.Length > 0)
        {
            foreach (var item in balls)
            {
                DestroyItem(item.gameObject);
            }
        }

        Bonus[] bonuses = FindObjectsOfType<Bonus>();
        if (bonuses.Length > 0)
        {
            foreach (var item in bonuses)
            {
                item.StopAndRemove();
            }
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();
        if (bonuses.Length > 0)
        {
            foreach (var item in bullets)
            {
                item.gameObject.SetActive(false);
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
