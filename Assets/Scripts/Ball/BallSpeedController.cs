using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedController : MonoBehaviour
{
    private const float MinSpeed = 10.8f;
    private const float MaxSpeed = 11.2f;
    private const int WaitFrame = 30;
    [SerializeField] private Rigidbody2D _rb;

    private void Update()
    {
        if (_rb.velocity.magnitude != 0)
        {
            if (Time.frameCount % WaitFrame == 0)
            {
                if (_rb.velocity.magnitude < MinSpeed || _rb.velocity.magnitude > MaxSpeed)
                {
                    float speedCorrect = MaxSpeed / _rb.velocity.magnitude;
                    _rb.velocity *= speedCorrect;
                }
            }
        }
    }
}
