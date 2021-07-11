using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnemy : MonoBehaviour, IDamagable
{
    public void ApplyDamage()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<ParticleSystem>().Play() ;
    }
}
