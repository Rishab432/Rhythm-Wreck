using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _bgmSource, _sfxSource;
    [SerializeField] private AudioClip _sfxClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _bgmSource.loop = true;
    }

    void OnSceneLoaded(Scene scene)
    {
        if (scene.name == "Settings")
        {
            // Write set volumes and toggles from GameData.
            _bgmSource.volume = 1.0f;
            _bgmSource.mute = false;
            _sfxSource.volume = 1.0f;
            _sfxSource.mute = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            _sfxSource.PlayOneShot(_sfxSource.clip);
        }
    }

    public void ChangeBGMVolume(float value)
    {
        _bgmSource.volume = value;
    }

    public void ChangeSFXVolume(float value)
    {
        _sfxSource.volume = value;
    }

    public void ToggleBGM(bool isOn)
    {
        _bgmSource.mute = !isOn;
    }

    public void ToggleSFX(bool isOn)
    {
        _sfxSource.mute = !isOn;
    }
}
