using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInScene : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider;

    public void SetActive(bool value)
    {
        _boxCollider.enabled = value;
        _spriteRenderer.enabled = value;
    }
}
