using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour
{
    public void ToJacksGame()
    {
        SceneManager.LoadScene("Jacks Game");
    }

    public void ToTylersGame()
    {
        SceneManager.LoadScene("Tyler Wen Game");
    }

    public void ToRustinsGame()
    {
        // Put loadscene with scene name here.
    }

    public void ToRishabsGame()
    {
        SceneManager.LoadScene("Dolphin Dive");
    }

    public void ToUselessShop()
    {
        SceneManager.LoadScene("Useless Shop");
    }
}
