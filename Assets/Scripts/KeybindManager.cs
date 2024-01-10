using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    private Dictionary<string, KeyCode> _keybinds;
    [SerializeField] private TextMeshProUGUI _upBind, _downBind, _leftBind, _rightBind;
    private string _setKey;

    void OnEnable()
    {
        _keybinds = DataManager.Instance.Data.Keybinds;
    }

    private void Update()
    {
        if (!string.IsNullOrWhiteSpace(_setKey))
        {
            Event currentEvent = Event.current;
            if (Input.anyKeyDown)
            {
                Input.
                _keybinds[_setKey] = currentEvent.keyCode;
                DataManager.Instance.Data.Keybinds[_setKey] = _keybinds[_setKey];
                if (_setKey == "Up") _upBind.text = _keybinds[_setKey].ToString();
                if (_setKey == "Down") _downBind.text = _keybinds[_setKey].ToString();
                if (_setKey == "Left") _leftBind.text = _keybinds[_setKey].ToString();
                if (_setKey == "Right") _rightBind.text = _keybinds[_setKey].ToString();
            }
        }
        _setKey = string.Empty;
    }

    public void UpClicked()
    {
        _setKey = "Up";
    }

    public void DownClicked()
    {
        _setKey = "Down";
    }

    public void LeftClicked()
    {
        _setKey = "Left";
    }

    public void RightClicked()
    {
        _setKey = "Right";
    }
}
