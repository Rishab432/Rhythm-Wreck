using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro comboText;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;
    static int score;


    //public float sfxDelay;
    void Start()
    {
        Instance = this;
        comboScore = 0;
        score = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        Instance.hitSFX.PlayDelayed(0.15f);
        score += (17 * comboScore);

    }
    public static void Miss()
    {
        if(comboScore >= 5)
            Instance.missSFX.PlayDelayed(0f);
        comboScore = 0;
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        comboText.text = comboScore.ToString() + "x";
    }
}