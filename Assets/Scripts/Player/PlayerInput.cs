using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private float _direction = 0f;

    [SerializeField] private GameObject _leftButton;
    [SerializeField] private GameObject _rightButton;

    public static event Action<float> OnMove;
    public static event Action OnClicked;

    //private Vector2 _startPosition = Vector2.zero;

    private void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClicked?.Invoke();
        }
#endif
#if UNITY_ANDROID
        //GetTouchInput();
        //_leftButton.SetActive(true);
        //_rightButton.SetActive(true);
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
        }
        //        }
        //            switch (touch.phase)
        //        {
        //            case TouchPhase.Moved:
        //                if (touch.position.x > _startPosition.x) _direction = 0.1f; 
        //                if (touch.position.x < _startPosition.x) _direction = -0.1f; 
        //                break;

        //            default:
        //                _startPosition = touch.position;
        //                _direction = 0f;
        //                break;
        //        }
        //        OnMove?.Invoke(_direction);
        //    }
        //}
    }

    public void MoveButton(bool left)
    {
        bool isLeft = left;
        _direction = isLeft ? -1f : 1f;
        OnMove?.Invoke(_direction);
    }

    public void Stop()
    {
        _direction = 0;
        OnMove?.Invoke(_direction);
    }
}