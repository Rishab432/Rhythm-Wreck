using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RustinScore : MonoBehaviour
{
    public TextMeshProUGUI Score;
    private static int _scoreNum = 0;
    private static int _timesReplayed = 0;
    // Start is called before the first frame update
    public static void SubScore()
    {
        _scoreNum -= 10;
    }
    public static void AddScore()
    {
        _scoreNum += 10;
    }
    public static void ResetTimes()
    {
        _timesReplayed = 0;
    }
    void Start()
    {
        Score = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _timesReplayed++;
            if (_timesReplayed > 1)
                _scoreNum -= 5;
        }
        Score.text = $"{_scoreNum}";
    }
}
