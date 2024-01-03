using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.ComponentModel;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance;

    private void Awake()
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
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                ToPlayerSelect();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Write the save code call here.
            Application.Quit();
        }
    }

    public void ToPlayerSelect()
    {
        SceneManager.LoadScene("PlayerSelect");
    }

    public void ToGameSelect()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        // Write the save code call here.
        Application.Quit();
    }
}
