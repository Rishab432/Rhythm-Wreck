using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHolder : MonoBehaviour
{
    public static ScoreHolder Instance;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private AudioClip _success;
    [SerializeField] private AudioClip _failure;
    public int Score { get; set; }
    public bool ShowResults { get; set; } = false;
    private float _waitTime = 1f;
    private bool _done = false;
    private float _returnTime = 5f;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (GameMusicManager.Instance.Audio.isPlaying)
            _scoreText.text = Score.ToString();
        if (ShowResults)
        {
            _waitTime -= Time.deltaTime;
            if (_waitTime < 0)
            {
                _scoreText.transform.localPosition = Vector3.zero;
                if (Score < 955)
                {
                    SoundManager.Instance.PlaySFX(_failure);
                    _scoreText.color = Color.grey;
                    _scoreText.text = "you lose...";
                }
                else if (Score < 1335)
                {
                    SoundManager.Instance.PlaySFX(_failure);
                    _scoreText.color = Color.magenta;
                    _scoreText.text = "eh, just ok..";
                }
                else if (Score < 1625)
                {
                    SoundManager.Instance.PlaySFX(_success);
                    _scoreText.color = Color.blue;
                    _scoreText.text = "not bad.";
                }
                else if (Score < 1815)
                {
                    SoundManager.Instance.PlaySFX(_success);
                    _scoreText.color = Color.yellow;
                    _scoreText.text = "quite good!";
                }
                else if (Score < 1910)
                {
                    SoundManager.Instance.PlaySFX(_success);
                    _scoreText.color = new Color(1f, 0.6f, 0.01f);
                    _scoreText.text = "spectacular!!";
                }
                else
                {
                    SoundManager.Instance.PlaySFX(_success);
                    _scoreText.color = Color.red;
                    _scoreText.text = "perfection!!!";
                }
                ShowResults = false;
                _done = true;
            }
        }

        if (_done)
        {
            _returnTime -= Time.deltaTime;
            if (_returnTime < 0 )
            {
                SoundManager.Instance.UnPause();
                SceneManager.LoadScene("GameSelect");
            }
        }
    }
}
