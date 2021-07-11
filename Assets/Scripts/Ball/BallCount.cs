using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCount : MonoBehaviour
{
    private static int _count = 0;
    public static event Action OnEnded;

    private void OnEnable()
    {
        _count++;
    }

    private void OnDisable()
    {
        _count--;
        if (_count < 1)
        {
            OnEnded?.Invoke();
        }
    }
}
