using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileSelect : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private GameObject _settingsButton, _fileButton1, _fileButton2, _fileButton3, _fileButton4;
    [SerializeField] private TextMeshProUGUI _fileName1, _fileName2, _fileName3, _fileName4;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private GameObject _inputField;
    private GameObject[] allObjects;

    void Start()
    {
        allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            Debug.Log(obj);
        }
        _inputField.SetActive(false);
    }

    public void SetFileName(string fileName)
    {
        _titleText.text = "Enter A File Name";
        _settingsButton.SetActive(false); _fileButton1.SetActive(false); _fileButton2.SetActive(false); _fileButton3.SetActive(false); _fileButton4.SetActive(false);
        _inputField.SetActive(true);
        _inputName.onEndEdit.AddListener((TextVal) =>
        {
            if (TextVal != "New Game" && !string.IsNullOrWhiteSpace(TextVal))
            {
                _fileName1.text = TextVal;
                fileName = TextVal;
                _inputField.SetActive(false);
                _settingsButton.SetActive(true); _fileButton1.SetActive(true); _fileButton2.SetActive(true); _fileButton3.SetActive(true); _fileButton4.SetActive(true);
                _titleText.text = "Select A File";
            }
            else
            {
                Debug.LogError("A proper name has not been set for the file.");
            }
        });
    }

    public void FirstFileSelect()
    {
        if (string.IsNullOrWhiteSpace(DataManager.Instance.Data.FileName1))
        {
            Debug.Log("First File Clicked");
            SetFileName(DataManager.Instance.Data.FileName1);
        }
    }

    public void SecondFileSelect()
    {
        if (string.IsNullOrWhiteSpace(DataManager.Instance.Data.FileName2))
        {
            SetFileName(DataManager.Instance.Data.FileName2);
        }
    }

    public void ThirdFileSelect()
    {
        if (string.IsNullOrWhiteSpace(DataManager.Instance.Data.FileName3))
        {
            SetFileName(DataManager.Instance.Data.FileName3);
        }
    }

    public void FourthFileSelect()
    {
        if (string.IsNullOrWhiteSpace(DataManager.Instance.Data.FileName4))
        {
            SetFileName(DataManager.Instance.Data.FileName4);
        }
    }
}
