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
        _upBind.text = _keybinds["Up"].ToString().ToUpper();
        _downBind.text = _keybinds["Down"].ToString().ToUpper();
        _leftBind.text = _keybinds["Left"].ToString().ToUpper();
        _rightBind.text = _keybinds["Right"].ToString().ToUpper();
    }

    private void Update()
    {
        if (!string.IsNullOrWhiteSpace(_setKey))
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("hehdaheahhahah");
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keyCode))
                    {
                        _keybinds[_setKey] = keyCode;
                        DataManager.Instance.Data.Keybinds[_setKey] = _keybinds[_setKey];
                        if (_setKey == "Up") _upBind.text = _keybinds[_setKey].ToString().ToUpper();
                        if (_setKey == "Down") _downBind.text = _keybinds[_setKey].ToString().ToUpper();
                        if (_setKey == "Left") _leftBind.text = _keybinds[_setKey].ToString().ToUpper();
                        if (_setKey == "Right") _rightBind.text = _keybinds[_setKey].ToString().ToUpper();
                        Debug.Log("heahehaha");
                        _setKey = string.Empty;
                        break;
                    }
                }
            }
        }
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
