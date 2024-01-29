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
    static public int MaxCombo;
    static public int[] TopScores = new int[3];

    static public int HighScore1;
    static public int HighScore2;
    static public int HighScore3;


    GameObject note;
    Color old;

    
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<SpriteRenderer>().color;
        _score = 0;
        MaxCombo = 0;



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

        CheckMaxCombo();
        CheckHighScores();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "LastNote"){
            Debug.Log("hitt");
            GameManager.Instance.Grade();
        }

        if (col.gameObject.tag == "Note"){
            active = true;
            note = col.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        active = false; 
    }

    public void CheckMaxCombo()
    {
        if(Combo > MaxCombo){
            MaxCombo = Combo;
            Debug.Log(MaxCombo);
        }
    }
    public void CheckHighScores()
    {
        HighScore1 = PlayerPrefs.GetInt("HighScore1");
        HighScore2 = PlayerPrefs.GetInt("HighScore2");
        HighScore3 = PlayerPrefs.GetInt("HighScore3");

        if (TotalScore > HighScore1)
        {
            PlayerPrefs.SetInt("HighScore3", HighScore2);
            PlayerPrefs.SetInt("HighScore2", HighScore1);
            PlayerPrefs.SetInt("HighScore1", TotalScore);
        }
        else if (TotalScore > HighScore2)
        {
            PlayerPrefs.SetInt("HighScore3", HighScore2);
            PlayerPrefs.SetInt("HighScore2", TotalScore);
        }
        else if (TotalScore > HighScore3)
        {
            PlayerPrefs.SetInt("HighScore3", TotalScore);
        }

    }


}
