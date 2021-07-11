using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private bool _isActiv;
    [SerializeField] private float Force = 300f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BallSound _ballSound;

    private void OnEnable()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerInput.OnClicked += BallActivate;
    }

    private void OnDisable()
    {
        PlayerInput.OnClicked -= BallActivate;
    }
    private void BallActivate()
    {
        if (!_isActiv)
        {
            _isActiv = true;
            transform.SetParent(null);
            _rb.bodyType = RigidbodyType2D.Dynamic;
            AddForce();
            _ballSound.PlaySoundAwake();
        }
    }

    public void AddForce(float direction = 0f)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(direction * (Force / 2), Force));
    }

    public void StartClone(float direction) 
    {
        _isActiv = true;
        _rb.bodyType = RigidbodyType2D.Dynamic;
        AddForce(direction);
        _ballSound.PlaySoundAwake();
    } 
}
