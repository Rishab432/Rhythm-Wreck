using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RustinScore : MonoBehaviour
{
    private int _rounds = 0;

    public TextMeshProUGUI Score;

    private static int _scoreNum = 0;
    private static int _timesReplayed = 0;

    private int[] _previousScores = new int[1];

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
    public void EndGame()
    {
        AddScore(_scoreNum);
        ScoreSort(_previousScores);
        _scoreNum = 0;
    }
    private void ScoreSort(int[] list)
    {
        for (int j = list.Length - 1; j > 0; j--)
        {
            bool sorted = true;
            for (int i = 0; i < j; i++)
            {
                int temp = 0;
                if (list[i] > list[i + 1])
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                    sorted = false;
                }
            }
            if (sorted)
                break;
        }

    }
    public void AddScore(int n)
    {
        int[] newList = new int[_previousScores.Length + 1];
        for (int i = 0; i < _previousScores.Length; i += 1)
        {
            newList[i] = _previousScores[i];
        }
        newList[newList.Length - 1] = n;
        _previousScores = newList;
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

        if (_rounds >= 10)
        {
            Debug.Log("End");
            EndGame();
        }
    }
}
