using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> OnMove;
    public static event Action OnClicked;

    private Vector2 _startPosition = Vector2.zero;
    private float _direction = 0f;

    private void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnClicked?.Invoke();
        }

#endif

#if UNITY_ANDROID
        GetTouchInput();
#endif
    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount > 1)
            {
                OnClicked?.Invoke();
            }


                switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (touch.position.x > _startPosition.x) _direction = 0.5f; 
                    if (touch.position.x < _startPosition.x) _direction = -0.5f; 
                    break;

                default:
                    _startPosition = touch.position;
                    _direction = 0f;
                    break;
            }
            OnMove?.Invoke(_direction);
        }
    }
}
