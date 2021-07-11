using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMove : MonoBehaviour
{
    private const float Speed = 5f;

    private void Update() {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}
