using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _subtitleText;
    private float _titleRotateSpeed = 0.5f;
    private float _subtitleAlphaSpeed = 0.01f;

    void Start()
    {
        _titleText.transform.eulerAngles = new Vector3(0, 0, -10);
        _subtitleText.transform.eulerAngles = new Vector3(0, 0, 0);
        float r = _subtitleText.color.r;
        float g = _subtitleText.color.g;
        float b = _subtitleText.color.b;
        _subtitleText.color = new Color(r, g, b, 0.5f);
        Debug.Log(_subtitleText.color.a);
    }

    void FixedUpdate()
    {
        _titleText.transform.Rotate(0, 0, _titleRotateSpeed, Space.Self);
        float currentAngle = _titleText.transform.eulerAngles.z;
        if (currentAngle > 180)
            currentAngle = -(180-(currentAngle % 180));
        if (currentAngle >= 15)
            _titleRotateSpeed = -_titleRotateSpeed;
        if (currentAngle <= -15)
            _titleRotateSpeed = -_titleRotateSpeed;

        
        Color currentColor = _subtitleText.color;
        float currentAlpha = currentColor.a;
        if (currentAlpha <= 0.25f)
            _subtitleAlphaSpeed = -_subtitleAlphaSpeed;
        if (currentAlpha >= 1)
            _subtitleAlphaSpeed = -_subtitleAlphaSpeed;
        _subtitleText.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha - _subtitleAlphaSpeed);
    }
}
