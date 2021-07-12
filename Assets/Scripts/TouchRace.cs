using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRace : MonoBehaviour
{  
    private bool _isRacePressed = false;

     private bool isLeft;
    [SerializeField] private PlayerInput input;
    void Update()
    {
        if (_isRacePressed)
        {         
            input.MoveButton(isLeft);
        }

        else if (!_isRacePressed)
        {
            input.Stop();
        }
    }
    public void onPointerDownRaceButton(bool left)
    {
        isLeft = left;
        _isRacePressed = true;
    }
    public void onPointerUpRaceButton()
    {
        _isRacePressed = false;
    }
}
