using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;

    void Start()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ToRestart()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToGameSelect()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameSelect");
    }

    public void ToFileSelect()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("FileSelect");
    }

    public void QuitGame()
    {
        // Write the save code call here.
        Application.Quit();
    }
}
