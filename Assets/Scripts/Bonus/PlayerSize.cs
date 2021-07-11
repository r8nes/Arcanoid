using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : Bonus, IRemovable
{
    [SerializeField] private bool _negativ;
    private const float Size = 0.5f;
    public override void Apply()
    {
        StartTimer();
        SetSize(_negativ ? -Size : Size);
    }

    public void Remove()
    {
        SetSize(_negativ ? Size : -Size);
    }

    private void SetSize(float value)
    {
        PlayerMove player = GetComponentInParent<PlayerMove>();
        if (player != null)
        {
            if (player.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                SpriteRenderer childSize = player.transform.Find("Player_Light").GetComponent<SpriteRenderer>();

                spriteRenderer.size = new Vector2(spriteRenderer.size.x + value, spriteRenderer.size.y);
                childSize.size = new Vector2(childSize.size.x + value, childSize.size.y);
            }

            if (player.TryGetComponent(out BoxCollider2D boxCollider))
            {
                boxCollider.size = new Vector2(boxCollider.size.x + value, boxCollider.size.y);
            }
        }
    }
}
