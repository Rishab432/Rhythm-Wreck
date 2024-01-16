using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;

    //public float sfxDelay;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        Instance.hitSFX.PlayDelayed(0.15f);

    }
    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.PlayDelayed(0.15f);
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
}