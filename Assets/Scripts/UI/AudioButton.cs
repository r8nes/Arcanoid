using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Space]
    [SerializeField] private Color _enableColor;
    [SerializeField] private Color _disableColor;
    [Space]
    [SerializeField] private Image _icon;
    [Space]
    [SerializeField] private Sprite _enableSprites;
    [SerializeField] private Sprite _disableSprites;
    private bool _enable;

    public void SetState(bool value) 
    {
        _enable = value; 
        Changed();
    }
    public void Change() 
    {
        _enable = !_enable;
        Changed();
    }

    private void Changed() {
        _button.image.color = _enable ? _enableColor : _disableColor;
        _icon.sprite = _enable ? _enableSprites : _disableSprites;
    } 
}
