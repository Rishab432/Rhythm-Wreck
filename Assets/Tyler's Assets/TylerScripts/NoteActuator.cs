using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class NoteActuator : MonoBehaviour
{
    public KeyCode Key;
    static public int Combo;
    private int _score;
    static public int TotalScore;
    bool active = false;
    static public bool Missed;

    public bool GradeS;
    public bool GradeA;
    public bool GradeB;
    public bool GradeF;

    GameObject note;
    Color old;

    
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<SpriteRenderer>().color;
        _score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0);
            if(active)
            {
                Destroy(note);
                Combo += 1;
                _score = 197 * Combo;
                TotalScore = TotalScore + _score;
            }
            else
            {
                Missed = true;
                Combo = 0;
            }

                
        }
        if (Input.GetKeyUp(Key))
            GetComponent<SpriteRenderer>().color = old;


        CheckHighScores(TotalScore);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            note = col.gameObject;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        active = false; 
    }

    private void CheckHighScores(int Score)
    {
        if (Score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            Debug.Log(Score);
        }
    }

    public int GetHighScores()
    {
        return PlayerPrefs.GetInt("Highscore");
    }

    public void Grade(int Score)
    {
        if (Score > 2500000)
        {
            GradeS = true;
            GradeA = false;
            GradeB = false;
            GradeF = false;
            FileManager.Instance.AddTokens(8);
        }
        else if (Score > 2000000)
        {
            GradeS = false;
            GradeA = true;
            GradeB = false;
            GradeF = false;
            FileManager.Instance.AddTokens(6);

        }
        else if (Score > 1200000)
        {
            GradeS = false;
            GradeA = false;
            GradeB = true;
            GradeF = false;
            FileManager.Instance.AddTokens(4);
        }
        else
        {
            GradeS = false;
            GradeA = false;
            GradeB = false;
            GradeF = true;
            FileManager.Instance.AddTokens(2);
        }
    }
}
