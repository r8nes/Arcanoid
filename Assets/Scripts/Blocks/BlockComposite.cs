using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComposite : MonoBehaviour
{
    public void ApplyDamage(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.05f);
        if (colliders.Length > 0)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IDamagable damagable ))
                {
                    damagable.ApplyDamage();
                    break;
                }
            }
        }
    }
}
