using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntToText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public void SetInt(int value) {
        _text.text = value.ToString();
    }
}
