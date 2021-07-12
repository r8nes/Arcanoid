using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float Speed = 25f;
    [SerializeField] private Animator _shake;

    private void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            _shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
            _shake.SetTrigger("Shake");
            damagable.ApplyDamage();
        }
        gameObject.SetActive(false);
    }
}
