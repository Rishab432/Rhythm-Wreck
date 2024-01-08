using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider, _sfxSlider;
    [SerializeField] private TextMeshProUGUI _bgmSliderText, _sfxSliderText;
    [SerializeField] private bool _toggleBGM, _toggleSFX;

    private void OnEnable()
    {
        _bgmSlider.value = DataManager.Instance.Data.BGMSliderVal;
        _sfxSlider.value = DataManager.Instance.Data.SFXSliderVal;
        _bgmSliderText.text = _bgmSlider.value.ToString("0.00");
        _sfxSliderText.text = _sfxSlider.value.ToString("0.00");
        _toggleBGM = DataManager.Instance.Data.BGMToggle;
        _toggleSFX = DataManager.Instance.Data.SFXToggle;
    }

    void Start()
    {
        SoundManager.Instance.ChangeBGMVolume(_bgmSlider.value);
        _bgmSlider.onValueChanged.AddListener((bgmVal) =>
        {
            _bgmSliderText.text = bgmVal.ToString("0.00");
            SoundManager.Instance.ChangeBGMVolume(bgmVal);
            DataManager.Instance.Data.BGMSliderVal = bgmVal;
        });

        SoundManager.Instance.ChangeSFXVolume(_sfxSlider.value);
        _sfxSlider.onValueChanged.AddListener((sfxVal) =>
        {
            _sfxSliderText.text = sfxVal.ToString("0.00");
            SoundManager.Instance.ChangeBGMVolume(sfxVal);
        });
    }

    public void Toggle()
    {
        if (_toggleBGM) SoundManager.Instance.ToggleBGM(); DataManager.Instance.Data.BGMToggle = _toggleBGM;
        if (_toggleSFX) SoundManager.Instance.ToggleSFX(); DataManager.Instance.Data.SFXToggle = _toggleSFX;
    }
}
